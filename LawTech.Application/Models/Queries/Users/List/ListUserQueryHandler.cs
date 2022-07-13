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

namespace LawTech.Application.Models.Queries.Users.List
{
    public class ListUserQueryHandler : IRequestHandler<ListUserQuery, IContractResponse>
    {
        private readonly IDefaultContext defaultContext;
        private readonly IMapper mapper;

        public ListUserQueryHandler(IDefaultContext defaultContext,
                                    IMapper mapper)
        {
            this.defaultContext = defaultContext;
            this.mapper = mapper;
        }

        public async Task<IContractResponse> Handle(ListUserQuery query, CancellationToken cancellationToken)
        {
            var users = await this.defaultContext.Users
                                  .ProjectTo<ListUserQueryResponse>(this.mapper.ConfigurationProvider)
                                  .ToListAsync(cancellationToken: cancellationToken);

            return ContractResponse.ValidContractResponse(string.Empty, users);
        }
    }
}
