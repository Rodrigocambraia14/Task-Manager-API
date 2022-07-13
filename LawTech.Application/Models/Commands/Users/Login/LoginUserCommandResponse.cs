using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Commands.Users.Login
{
    public class LoginUserCommandResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string? ImageProfile { get; set; }

        public DateTime CreatedDate { get; set; }

        public string RoleName { get; set; }

        public Guid RoleId { get; set; }

        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
