using LawTech.CrossCutting.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Queries.Tasks.List
{
    public class ListTaskQuery : IRequest<IContractResponse>
    {
        public Guid UserId { get; set; }
    }
}
