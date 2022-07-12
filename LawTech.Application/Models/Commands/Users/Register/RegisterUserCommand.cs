using LawTech.CrossCutting.Enums;
using LawTech.CrossCutting.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<IContractResponse>
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public UserType UserType { get; set; }

        public string Password { get; set; }
    }
}
