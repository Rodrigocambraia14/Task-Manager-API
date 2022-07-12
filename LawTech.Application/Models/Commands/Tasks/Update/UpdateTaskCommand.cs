using LawTech.CrossCutting.Enums;
using LawTech.CrossCutting.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = LawTech.CrossCutting.Enums.TaskStatus;

namespace LawTech.Application.Models.Commands.Tasks.Update
{
    public class UpdateTaskCommand : IRequest<IContractResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        public Guid UserId { get; set; }
    }
}
