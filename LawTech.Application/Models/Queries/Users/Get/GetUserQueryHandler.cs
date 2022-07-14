using AutoMapper;
using AutoMapper.QueryableExtensions;
using LawTech.CrossCutting.Helper;
using LawTech.Infra.Context.Persistence.Context.Default;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Queries.Users.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IContractResponse>
    {
        private readonly IDefaultContext defaultContext;
        private readonly IMapper mapper;

        public GetUserQueryHandler(IDefaultContext defaultContext,
                                   IMapper mapper)
        {
            this.defaultContext = defaultContext;
            this.mapper = mapper;
        }

        public async Task<IContractResponse> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var user = await this.defaultContext.Users
                                 .Where(x => x.Id == query.UserId)
                                 .ProjectTo<GetUserQueryResponse>(this.mapper.ConfigurationProvider)
                                 .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user is null)
                throw new Exception("Usuário não encontrado !");

            return ContractResponse.ValidContractResponse(string.Empty, user);
        }
    }
}
