using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Queries.Users.Get
{
    public class GetUserQueryResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string? ImageProfile { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<GetUserLoginResponse> UserLogins { get; set; }

        public ICollection<GetUserTaskResponse> Tasks { get; set; }
    }


    public sealed class GetUserLoginResponse
    {
        public DateTime CreatedDate { get; set; }
    }

    public sealed class GetUserTaskResponse
    {
        public Guid Id { get; set; }
    }
}
