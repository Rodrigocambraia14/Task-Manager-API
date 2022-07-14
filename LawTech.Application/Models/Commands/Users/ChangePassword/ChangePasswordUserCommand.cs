using LawTech.CrossCutting.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Users.ChangePassword
{
    public class ChangePasswordUserCommand : IRequest<IContractResponse>
    {
        public Guid UserId { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }
    }
}
