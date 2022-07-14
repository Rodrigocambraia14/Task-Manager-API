using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LawTech.CrossCutting.Enums
{
    public enum UserStatus
    {
        [Description("Ativo")]
        Active = 1,

        [Description("Bloqueado")]
        Blocked = 2
    }
}
