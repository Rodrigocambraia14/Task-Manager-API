using LawTech.CrossCutting.Enums;
using LawTech.CrossCutting.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = LawTech.CrossCutting.Enums.TaskStatus;

namespace LawTech.Application.Models.Commands.Tasks.Create
{
    public class CreateTaskCommand : IRequest<IContractResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.Ready;

        public TaskPriority Priority { get; set; }

        public Guid UserId { get; set; }
    }
}
