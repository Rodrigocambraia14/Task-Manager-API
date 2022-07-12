using LawTech.Context.Default.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = LawTech.Context.Default.Entities.Task;

namespace LawTech.Infra.Context.Persistence.Context.Default
{
    public interface IDefaultContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public DbSet<UserRole> userRoles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Role> RoleClaims { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<Task> Tasks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
