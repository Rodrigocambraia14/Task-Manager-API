using AutoMapper;
using LawTech.CrossCutting.Helper;
using LawTech.Infra.Context.Persistence.Context.Default;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Tasks.Update
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, IContractResponse>
    {
        private readonly IDefaultContext defaultContext;
        private readonly IMapper mapper;

        public UpdateTaskCommandHandler(IDefaultContext defaultContext,
                                        IMapper mapper)
        {
            this.defaultContext = defaultContext;
            this.mapper = mapper;
        }

        public async Task<IContractResponse> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
        {
            var task = await this.defaultContext.Tasks.Where(x => command.Id == x.Id)
                                                      .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (task is null)
                throw new Exception("Tarefa não encontrada !");

            _ = this.mapper.Map(command, task,
                   opt => opt.AfterMap((src, dest) =>
                   {
                       dest.UpdatedBy = command.UserId;
                       dest.UpdatedDate = DateTime.Now;
                   })
                  );

            this.defaultContext.Tasks.Update(task);

            await this.defaultContext.SaveChangesAsync(cancellationToken);

            return ContractResponse.ValidContractResponse("Tarefa atualizada com sucesso !");
        }
    }
}
