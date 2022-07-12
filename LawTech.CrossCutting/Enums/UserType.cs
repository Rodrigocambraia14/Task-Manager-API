using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.CrossCutting.Enums
{
    public enum UserType
    {
        [Description("Admin")]
        Admin = 1,

        [Description("Usuario")]
        User = 2
    }
}
