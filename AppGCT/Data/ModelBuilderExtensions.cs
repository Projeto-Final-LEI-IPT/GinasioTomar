using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace AppGCT.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var pwd = "123!aBc";
            var passwordHasher = new PasswordHasher<Utilizador>();

            //seed roles
            var adminRole = new IdentityRole("Administrador");
            adminRole.NormalizedName = adminRole.Name.ToUpper();

            var ginasioRole = new IdentityRole("Ginásio");
            ginasioRole.NormalizedName = ginasioRole.Name.ToUpper();

            var socioRole = new IdentityRole("Sócio");
            socioRole.NormalizedName = socioRole.Name.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>()
            { adminRole, ginasioRole, socioRole
            };
            builder.Entity<IdentityRole>().HasData(roles);

            //seed admin user
            var adminUser = new Utilizador
            {
                UserName = "admin@localhost",
                Email = "admin@localhost",
                EmailConfirmed = true,
                Nome = "Administrador",
                NumSocio = " ",
                Morada = "Ginásio Clube de Tomar",
                EstadoUtilizador = "A",
                NIF = "999999999",
                PhoneNumber = "999999999",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                DataAprovacao = DateTime.Now,   
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                DataNascim = DateTime.Now             
            };

            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

            List<Utilizador> users = new List<Utilizador>()
            {adminUser
            }
            ;

            builder.Entity<Utilizador>().HasData(users);

            //seed role to admin user
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Administrador").Id
            });

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);  

        }
    }
}
