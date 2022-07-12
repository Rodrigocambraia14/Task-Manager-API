using LawTech.Context.Default.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = LawTech.Context.Default.Entities.Task;

namespace LawTech.Infra.Context.Persistence.Context.Default
{
    public class DefaultContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IDefaultContext
    {
        private readonly IConfiguration configuration;

        public DefaultContext(DbContextOptions<DefaultContext> options, IConfiguration configuration)
        : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public DbSet<UserRole> userRoles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Role> RoleClaims { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(User).Assembly);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring = this.configuration.GetConnectionString("DefaultConnectionString");
            optionsBuilder.UseSqlServer(connectionstring);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
