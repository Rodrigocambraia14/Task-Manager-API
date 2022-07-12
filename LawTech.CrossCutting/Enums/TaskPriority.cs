using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.CrossCutting.Enums
{
    public enum TaskPriority
    {
        [Description("Alta")]
        High = 1,

        [Description("Media")]
        Medium = 2,

        [Description("Baixa")]
        Low = 3,
    }
}
