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
                                  .Where(x => x.UserRoles.All(y => y.Role.Name != "Admin"))
                                  .Select(x => new ListUserQueryResponse()
                                  {
                                      Id = x.Id,
                                      ImageProfile = x.ImageProfile,
                                      Name = x.Name,
                                      UserName = x.UserName,
                                      Email = x.Email,
                                      CreatedDate = x.CreatedDate,
                                      Tasks = x.Tasks.Count,
                                      Status = x.Status,
                                      LastLogin = x.UserLogins.Count > 0 ? x.UserLogins.Max(y => y.CreatedDate) : null
                                  })
                                  .ToListAsync(cancellationToken: cancellationToken);

            return ContractResponse.ValidContractResponse(string.Empty, users);
        }
    }
}
