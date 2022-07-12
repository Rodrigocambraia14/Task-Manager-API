using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Context.Default.Entities
{
    public class User : IdentityUser<Guid>
    {
        public override string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string? ImageProfile { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<UserLogin> UserLogins { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
