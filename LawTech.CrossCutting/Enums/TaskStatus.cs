using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.CrossCutting.Enums
{
    public enum TaskStatus
    {
        [Description("Pronta")]
        Ready = 1,

        [Description("Em andamento")]
        Doing = 2,

        [Description("Finalizada")]
        Done = 3,

        [Description("Removida")]
        Deleted = 4,
    }
}
