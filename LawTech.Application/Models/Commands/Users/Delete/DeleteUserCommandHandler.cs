using LawTech.CrossCutting.Helper;
using LawTech.Infra.Context.Persistence.Context.Default;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Users.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IContractResponse>
    {
        private readonly IDefaultContext defaultContext;

        public DeleteUserCommandHandler(IDefaultContext defaultContext)
        {
            this.defaultContext = defaultContext;
        }

        public async Task<IContractResponse> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = await this.defaultContext.Users.FirstOrDefaultAsync(x => x.Id == command.UserId, cancellationToken: cancellationToken);

            if (user == null)
                throw new Exception("Usuário não encontrado !");

            this.defaultContext.Users.Remove(user);

            await this.defaultContext.SaveChangesAsync(cancellationToken);

            return ContractResponse.ValidContractResponse("Usuário removido com sucesso !");
            
        }
    }
}
