using LawTech.Context.Default.Entities;
using LawTech.Infra.Context.Persistence.Context.Default;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ImpactaLawTech_Test.Seeds
{
    public class InitialSeed
    {
        public static void SeedRoles(DefaultContext defaultContext)
        {
            if (!defaultContext.Roles.Where(x => x.Name == "Admin").Any())
            {
                defaultContext.Roles.Add(new Role()
                {
                    CreatedDate = DateTime.Now,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Description = "Grupo de administradores"
                });

                defaultContext.SaveChanges();
            }
            if (!defaultContext.Roles.Where(x => x.Name == "Usuario").Any())
            {
                defaultContext.Roles.Add(new Role()
                {
                    CreatedDate = DateTime.Now,
                    Name = "Usuario",
                    NormalizedName = "USUARIO",
                    Description = "Grupo de usuarios"
                });

                defaultContext.SaveChanges();
            }
        }

        public static void SeedUsers(DefaultContext defaultContext, UserManager<User> userManager)
        {
            if (!defaultContext.Users.Where(x => x.Name == "admin").Any())
            {
                var user = new User()
                {
                    Name = "admin",
                    Email = "teste_lawtech@gmail.com",
                    UserName = "admin",
                    Password = "admin",
                    CreatedDate = DateTime.Now,
                };

                userManager.CreateAsync(user, "admin").GetAwaiter().GetResult();

                user = defaultContext.Users.Where(x => x.UserName == "admin").FirstOrDefaultAsync().GetAwaiter().GetResult();

                userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();

                defaultContext.SaveChangesAsync().GetAwaiter().GetResult();

            }
        }
    }
}
