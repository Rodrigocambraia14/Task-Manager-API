using LawTech.CrossCutting.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Tasks.Delete
{
    public class DeleteTaskCommand : IRequest<IContractResponse>
    {
        public Guid Id { get; set; }
    }
}
