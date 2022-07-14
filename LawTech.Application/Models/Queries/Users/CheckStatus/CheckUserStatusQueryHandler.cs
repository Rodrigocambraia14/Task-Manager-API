using LawTech.CrossCutting.Helper;
using LawTech.Infra.Context.Persistence.Context.Default;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Queries.Users.CheckStatus
{
    public class CheckUserStatusQueryHandler : IRequestHandler<CheckUserStatusQuery, IContractResponse>
    {
        private readonly IDefaultContext defaultContext;

        public CheckUserStatusQueryHandler(IDefaultContext defaultContext)
        {
            this.defaultContext = defaultContext;
        }

        public async Task<IContractResponse> Handle(CheckUserStatusQuery query, CancellationToken cancellationToken)
        {
            var userStatus = await this.defaultContext.Users.Where(x => x.Id == query.UserId)
                                                            .Select(x => x.Status)
                                                            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return ContractResponse.ValidContractResponse(string.Empty, userStatus);
                                                            
        }
    }
}
