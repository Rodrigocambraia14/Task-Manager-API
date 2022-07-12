using LawTech.Application.Models.Commands.Users;
using LawTech.Context.Default.Entities;
using LawTech.Infra.Context.Persistence.Context.Default;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LawTech.Infra.Ioc
{
    public static class ResolveDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var connect = configuration.GetConnectionString("DefaultConnectionString");

            services.AddDbContext<DefaultContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddEntityFrameworkStores<DefaultContext>()
                .AddDefaultTokenProviders();



            #region Services

            services.AddScoped<IDefaultContext, DefaultContext>();
            #endregion Services

            services.AddAutoMapper(typeof(UserCommandProfile));
            //services.AddValidatorsFromAssembly(typeof(LoginUserCommandValidator).Assembly);
        }
    }
}