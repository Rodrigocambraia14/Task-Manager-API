using LawTech.Context.Default.Entities;
using LawTech.CrossCutting.Helper;
using LawTech.Infra.Context.Persistence.Context.Default;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Users.ChangePassword
{
    public class ChangePasswordUserCommandHandler : IRequestHandler<ChangePasswordUserCommand, IContractResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly IDefaultContext defaultContext;

        public ChangePasswordUserCommandHandler(UserManager<User> userManager,
                                                IDefaultContext defaultContext)
        {
            this.userManager = userManager;
            this.defaultContext = defaultContext;
        }

        public async Task<IContractResponse> Handle(ChangePasswordUserCommand command, CancellationToken cancellationToken)
        {
            var user = await this.userManager.FindByIdAsync(command.UserId.ToString());

            if (user is null)
                throw new Exception("Usuário não encontrado !");

            var result = await this.userManager.ChangePasswordAsync(user, command.Password, command.NewPassword);

            if (!result.Succeeded)
                throw new Exception("Senha atual incorreta.");

            return ContractResponse.ValidContractResponse("Senha alterada com sucesso !");
        }
    }
}
