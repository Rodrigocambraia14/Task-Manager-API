using LawTech.CrossCutting.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Queries.Users.CheckStatus
{
    public class CheckUserStatusQuery : IRequest<IContractResponse>
    {
        public Guid UserId { get; set; }
    }
}
