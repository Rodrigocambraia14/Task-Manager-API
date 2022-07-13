using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Queries.Users.List
{
    public class ListUserQueryResponse
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string? ImageProfile { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<UserRoleResponse> UserRoles { get; set; }

        public ICollection<UserLoginResponse> UserLogins { get; set; }

        public ICollection<TaskResponse> Tasks { get; set; }
    }

    public sealed class UserRoleResponse
    {
        public RoleResponse Role { get; set; }
    }

    public sealed class RoleResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public sealed class UserLoginResponse
    {
        public DateTime CreatedDate { get; set; }
    }

    public sealed class TaskResponse
    {
        public Guid Id { get; set; }
    }
}
