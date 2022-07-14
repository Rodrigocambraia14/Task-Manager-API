using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Queries.Tasks.List
{
    public class ListTaskQueryValidator : AbstractValidator<ListTaskQuery>
    {
        public ListTaskQueryValidator()
        {
        }
    }
}
