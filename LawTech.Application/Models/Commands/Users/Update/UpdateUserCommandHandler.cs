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

namespace LawTech.Application.Models.Commands.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IContractResponse>
    {
        private readonly IDefaultContext defaultContext;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IDefaultContext defaultContext,
                                        IMapper mapper)
        {
            this.defaultContext = defaultContext;
            this.mapper = mapper;
        }

        public async Task<IContractResponse> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await this.defaultContext.Users.Where(x => x.Id == command.UserId)
                                                      .FirstOrDefaultAsync();

            if (user is null)
                throw new Exception("Usuário não encontrado !");

            _ = this.mapper.Map(command, user,
                    opt => opt.AfterMap((src, dest) =>
                    {
                        dest.NormalizedEmail = command.Email.ToUpper();
                    })
                  );

            this.defaultContext.Users.Update(user);

            await this.defaultContext.SaveChangesAsync(cancellationToken);

            return ContractResponse.ValidContractResponse("Usuário atualizado com sucesso !");
        }
    }
}
