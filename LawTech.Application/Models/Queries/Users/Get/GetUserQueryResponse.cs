using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Queries.Users.Get
{
    public class GetUserQueryResponse
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string? ImageProfile { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<GetUserRoleResponse> UserRoles { get; set; }

        public ICollection<GetUserLoginResponse> UserLogins { get; set; }

        public ICollection<TaskResponse> Tasks { get; set; }
    }

    public sealed class GetUserRoleResponse
    {
        public GetRoleResponse Role { get; set; }
    }

    public sealed class GetRoleResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public sealed class GetUserLoginResponse
    {
        public DateTime CreatedDate { get; set; }
    }

    public sealed class GetTaskResponse
    {
        public Guid Id { get; set; }
    }
}
