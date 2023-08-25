using AppGCT.Areas.Identity.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;

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
                RoleAux = "Administrador",
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

            //Seed Época
            var epoca = new Epoca
            {
                IdEpoca = 1,
                NomeEpoca = "2023/2024",
                DataInicio = new DateTime(2023, 9, 1),
                DataFim = new DateTime(2024, 7, 31),
                EstadoEpoca = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
  
            };
            List<Epoca> epocas = new List<Epoca>(){epoca};
            builder.Entity<Epoca>().HasData(epocas);

            //Seed Classes
            var classe = new Classe
            {
                IdClasse = 1,
                NomeClasse = "Aprendizagem 1",
                EstadoClasse = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };

            var classe2 = new Classe
            {
                IdClasse = 2,
                NomeClasse = "Aprendizagem 2",
                EstadoClasse = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var classe3 = new Classe
            {
                IdClasse = 3,
                NomeClasse = "Aprendizagem 3",
                EstadoClasse = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var classe4 = new Classe
            {
                IdClasse = 4,
                NomeClasse = "Acrobática 1",
                EstadoClasse = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var classe5 = new Classe
            {
                IdClasse = 5,
                NomeClasse = "Acrobática 2",
                EstadoClasse = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var classe6 = new Classe
            {
                IdClasse = 6,
                NomeClasse = "Acrobática 3",
                EstadoClasse = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var classe7 = new Classe
            {
                IdClasse = 7,
                NomeClasse = "Trampolins 1",
                EstadoClasse = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var classe8 = new Classe
            {
                IdClasse = 8,
                NomeClasse = "Trampolins 2",
                EstadoClasse = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var classe9 = new Classe
            {
                IdClasse = 9,
                NomeClasse = "Ginástica para todos–Júnior",
                EstadoClasse = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var classe10 = new Classe
            {   
                IdClasse = 10,
                NomeClasse = "Ginástica para todos–Universitários",
                EstadoClasse = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            List<Classe> classes = new List<Classe>() { classe, classe2, classe3,classe4,classe5,classe6,classe7,classe8,classe9, classe10};
            builder.Entity<Classe>().HasData(classes);

            //Seed Metodos Pagamento
            var metodo = new MetodoPagamento
            {
                CodMetodo = "00",
                DescMetodo = "Numerário",
                ValorDesconto = 0,
                EstadoMetodo = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var metodo1 = new MetodoPagamento
            {
                CodMetodo = "01",
                DescMetodo = "Transferência Bancária",
                ValorDesconto = 1,
                EstadoMetodo = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var metodo2 = new MetodoPagamento
            {
                CodMetodo = "02",
                DescMetodo = "Terminal Pagamento Automático(TPA)",
                ValorDesconto = 0,
                EstadoMetodo = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            List<MetodoPagamento> metodos = new List<MetodoPagamento>() { metodo,metodo1,metodo2};
            builder.Entity<MetodoPagamento>().HasData(metodos);

            //Seed Descontos
            var desconto = new Desconto
            {
                CodDesconto = "00",
                DescDesconto = "Bolsa",
                EstadoDesconto = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var desconto1 = new Desconto
            {
                CodDesconto = "01",
                DescDesconto = "Parentesco(1º familiar)",
                EstadoDesconto = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var desconto2 = new Desconto
            {
                CodDesconto = "02",
                DescDesconto = "Parentesco(2º familiar)",
                EstadoDesconto = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var desconto3 = new Desconto
            {
                CodDesconto = "03",
                DescDesconto = "Parentesco(3º familiar)",
                EstadoDesconto = "A",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            List<Desconto> descontos = new List<Desconto>() { desconto, desconto1, desconto2, desconto3};
            builder.Entity<Desconto>().HasData(descontos);

            //Seed Rúbricas Preçário
            var rub = new Rubrica
            {
                CodRubrica = "001",
                DescricaoRubrica = "Inscrição",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 1,
                IVlrUnit = "S",
                ValorUnitario = 15,
                IPagInscricao = "S",
                TipoRubrica = "G",
                LocalTreino = "",
                Horario = "",
                HorasSemanais= "",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var rub1 = new Rubrica
            {
                CodRubrica = "002",
                DescricaoRubrica = "Filiação FGP",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 2,
                IVlrUnit = "S",
                ValorUnitario = 10,
                IPagInscricao = "S",
                TipoRubrica = "G",
                LocalTreino = "",
                Horario = "",
                HorasSemanais = "",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                
            };
            var rub2 = new Rubrica
            {
                CodRubrica = "003",
                DescricaoRubrica = "Seguro",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 3,
                IVlrUnit = "S",
                ValorUnitario = 30,
                IPagInscricao = "S",
                TipoRubrica = "G",
                LocalTreino = "",
                Horario = "",
                HorasSemanais = "",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var rub3 = new Rubrica
            {
                CodRubrica = "004",
                DescricaoRubrica = "Quota Sócio",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 4,
                IVlrUnit = "S",
                ValorUnitario = 15,
                IPagInscricao = "N",
                TipoRubrica = "S",
                LocalTreino = "",
                Horario = "",
                HorasSemanais = "",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            List<Rubrica> rubricas = new List<Rubrica>() { rub, rub1, rub2,rub3};
            builder.Entity<Rubrica>().HasData(rubricas);
        }
    }
}
