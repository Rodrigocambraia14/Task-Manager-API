using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Users.ChangePassword
{
    public class ChangePasswordUserCommandValidator : AbstractValidator<ChangePasswordUserCommand>
    {
        public ChangePasswordUserCommandValidator()
        {
        }
    }
}
