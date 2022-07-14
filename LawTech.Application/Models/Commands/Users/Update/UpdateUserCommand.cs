using LawTech.CrossCutting.Enums;
using LawTech.CrossCutting.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Users.Update
{
    public class UpdateUserCommand : IRequest<IContractResponse>
    {
        public Guid UserId { get; set; }

        public Guid RequesterId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public UserStatus Status { get; set; }
    }
}
