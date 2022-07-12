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

namespace LawTech.Application.Models.Queries.Tasks.List
{
    public class ListTaskQueryHandler : IRequestHandler<ListTaskQuery, IContractResponse>
    {
        private readonly IDefaultContext defaultContext;
        private readonly IMapper mapper;

        public ListTaskQueryHandler(IDefaultContext defaultContext,
                                    IMapper mapper)
        {
            this.defaultContext = defaultContext;
            this.mapper = mapper;
        }

        public async Task<IContractResponse> Handle(ListTaskQuery query, CancellationToken cancellationToken)
        {
            var tasks = await this.defaultContext.Tasks.Where(x => x.UserId == query.UserId &&
                                                                   x.Status != CrossCutting.Enums.TaskStatus.Deleted)
                                                       .ProjectTo<ListTaskQueryResponse>(this.mapper.ConfigurationProvider)
                                                       .ToListAsync(cancellationToken: cancellationToken);

            return ContractResponse.ValidContractResponse(string.Empty, tasks);
        }
    }
}
