using LawTech.Context.Default.Entities;
using LawTech.CrossCutting.Helper;
using LawTech.Infra.Context.Persistence.Context.Default;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LawTech.Application.Models.Commands.Users.Login
{ 
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, IContractResponse>
    {
        private readonly DefaultContext defaultContext;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration options;

        public LoginUserCommandHandler(DefaultContext defaultContext,
                                       SignInManager<User> signInManager,
                                       IConfiguration options)
        {
            this.defaultContext = defaultContext;
            this.signInManager = signInManager;
            this.options = options;
        }

        public async Task<IContractResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await this.defaultContext.Users.FirstOrDefaultAsync(x => x.UserName == command.UserName, cancellationToken: cancellationToken);

            if (user is null)
                throw new Exception("Usuário não encontrado !");

            var login = await this.signInManager.PasswordSignInAsync(user, command.Password, false, false);

            if (login.Succeeded)
            {
                UserLogin userLogin = new()
                {
                    LoginProvider = "Default",
                    
                    CreatedDate = DateTime.Now,
                    Token = BuildToken(user.Email),
                    ExpirationDate = DateTime.Now.AddHours(double.Parse(this.options.GetSection("TokenSettings:ExpiresInHours").Value)),
                    UserId = user.Id
                };

                this.defaultContext.UserLogins.Add(userLogin);

                await this.defaultContext.SaveChangesAsync(cancellationToken);

                user.UserLogins.Add(userLogin);

                return ContractResponse.ValidContractResponse(string.Empty, user);
            }
            else
                throw new Exception("Login ou senha incorretos !");
        }

        private string BuildToken(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, email),
                new Claim("ClubeApp", "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(this.options.GetSection("TokenSettings:Secret").Value));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                issuer: this.options.GetSection("TokenSettings:Issuer").Value,
                audience: this.options.GetSection("TokenSettings:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddHours(double.Parse(this.options.GetSection("TokenSettings:ExpiresInHours").Value)),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
