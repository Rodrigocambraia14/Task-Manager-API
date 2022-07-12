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

namespace LawTech.Application.Models.Commands.Tasks.Create
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, IContractResponse>
    {
        private readonly IDefaultContext defaultContext;
        private readonly IMapper mapper;

        public CreateTaskCommandHandler(IDefaultContext defaultContext,
                                        IMapper mapper)
        {
            this.defaultContext = defaultContext;
            this.mapper = mapper;
        }

        public async Task<IContractResponse> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
        {
            var alreadyHasTask = await this.defaultContext.Tasks.Where(x => x.Name.ToLower() == command.Name.ToLower() &&
                                                                            x.UserId == command.UserId &&
                                                                            x.Status != CrossCutting.Enums.TaskStatus.Deleted)
                                                                .AnyAsync(cancellationToken: cancellationToken);

            if (alreadyHasTask)
                throw new Exception("Você já possui uma tarefa com o mesmo nome !");

            var task = this.mapper.Map<Context.Default.Entities.Task>(command,
                   opt => opt.AfterMap((src, dest) =>
                   {
                       dest.CreatedDate = DateTime.Now;
                       dest.CreatedBy = command.UserId;
                   })
                  );

            await this.defaultContext.Tasks.AddAsync(task, cancellationToken);

            await this.defaultContext.SaveChangesAsync(cancellationToken);

            return ContractResponse.ValidContractResponse("Tarefa criada com sucesso !");
        }
    }
}
