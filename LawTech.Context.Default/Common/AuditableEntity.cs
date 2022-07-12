using LawTech.Context.Default.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Context.Default.Common
{
    public class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public User CreatedByUser { get; set; }

        public User UpdatedByUser { get; set; }
    }
}
