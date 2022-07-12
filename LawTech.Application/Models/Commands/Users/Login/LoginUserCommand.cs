using LawTech.CrossCutting.Helper;
using MediatR;

namespace LawTech.Application.Models.Commands.Users.Login
{ 
    public class LoginUserCommand : IRequest<IContractResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
