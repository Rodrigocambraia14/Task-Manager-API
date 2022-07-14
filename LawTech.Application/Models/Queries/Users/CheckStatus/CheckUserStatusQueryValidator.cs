using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Queries.Users.CheckStatus
{
    public class CheckUserStatusQueryValidator : AbstractValidator<CheckUserStatusQuery>
    {
        public CheckUserStatusQueryValidator()
        {
        }
    }
}
