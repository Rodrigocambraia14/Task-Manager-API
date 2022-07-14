using LawTech.CrossCutting.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Users.Delete
{
    public class DeleteUserCommand : IRequest<IContractResponse>
    {
        public Guid UserId { get; set; }
    }
}
