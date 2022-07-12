using LawTech.Context.Default.Common;
using LawTech.CrossCutting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Context.Default.Entities
{
    public class Task  : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CrossCutting.Enums.TaskStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
