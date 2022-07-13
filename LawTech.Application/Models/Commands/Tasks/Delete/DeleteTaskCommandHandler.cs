using LawTech.CrossCutting.Helper;
using LawTech.Infra.Context.Persistence.Context.Default;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Tasks.Delete
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, IContractResponse>
    {
        private readonly IDefaultContext defaultContext;

        public DeleteTaskCommandHandler(IDefaultContext defaultContext)
        {
            this.defaultContext = defaultContext;
        }

        public async Task<IContractResponse> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
        {
            var task = await this.defaultContext.Tasks.Where(x => command.Id == x.Id)
                                                       .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (task is null)
                throw new Exception("Nenhuma tarefa encontrada, por favor tente novamente !");

            task.Status = CrossCutting.Enums.TaskStatus.Deleted;

            this.defaultContext.Tasks.Update(task);

            await this.defaultContext.SaveChangesAsync(cancellationToken: cancellationToken);

            return ContractResponse.ValidContractResponse("Tarefa(s) removidas com sucesso !");
        }
    }
}
