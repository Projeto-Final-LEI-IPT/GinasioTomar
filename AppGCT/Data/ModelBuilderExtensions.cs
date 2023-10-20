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
            var pwd = "admin_GCT23";
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
                CodPostal = "9999-999",
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
                ICobrancUltimoMes = "N",
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
                DataModificacao = DateTime.MinValue,
                ClasseId = null
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
                ClasseId = null
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
                DataModificacao = DateTime.MinValue,
                ClasseId = null
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
                DataModificacao = DateTime.MinValue,
                ClasseId = null
            };
            var rub4 = new Rubrica
            {
                CodRubrica = "005",
                DescricaoRubrica = "Mens. Aprendizagem 1",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 1,
                IVlrUnit = "S",
                ValorUnitario = 27,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª e 5ª 17h45 às 18h30 (2x semana)",
                HorasSemanais = "1h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 1             
            };
            var rub5 = new Rubrica
            {
                CodRubrica = "006",
                DescricaoRubrica = "Mens. Aprendizagem 2",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 2,
                IVlrUnit = "S",
                ValorUnitario = 30,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª e 5ª 18h15 às 19h30  (2x semana)",
                HorasSemanais = "2h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 2
            };
            var rub6 = new Rubrica
            {
                CodRubrica = "007",
                DescricaoRubrica = "Mens. Aprendizagem 3",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 3,
                IVlrUnit = "S",
                ValorUnitario = 32,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "3ª e 6ª 17h45 às 19h15  (2x semana)",
                HorasSemanais = "3h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 3
            };
            var rub7 = new Rubrica
            {
                CodRubrica = "008",
                DescricaoRubrica = "Mens. Acrobática 1",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 4,
                IVlrUnit = "S",
                ValorUnitario = 40,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)",
                HorasSemanais = "7h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 4
            };
            var rub8 = new Rubrica
            {
                CodRubrica = "009",
                DescricaoRubrica = "Mens. Acrobática 2",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 5,
                IVlrUnit = "S",
                ValorUnitario = 45,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)",
                HorasSemanais = "9h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 5
            };
            var rub9 = new Rubrica
            {
                CodRubrica = "010",
                DescricaoRubrica = "Mens. Acrobática 3",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 6,
                IVlrUnit = "S",
                ValorUnitario = 52,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)",
                HorasSemanais = "12h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 6
            };
            var rub10 = new Rubrica
            {
                CodRubrica = "011",
                DescricaoRubrica = "Mens. Trampolins 1",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 7,
                IVlrUnit = "S",
                ValorUnitario = 36,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)",
                HorasSemanais = "5h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 7
            };
            var rub11 = new Rubrica
            {
                CodRubrica = "012",
                DescricaoRubrica = "Mens. Trampolins 2",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 8,
                IVlrUnit = "S",
                ValorUnitario = 45,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)",
                HorasSemanais = "9h15",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 8
            };
            var rub12 = new Rubrica
            {
                CodRubrica = "013",
                DescricaoRubrica = "Mens. GPT – Júnior",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 9,
                IVlrUnit = "S",
                ValorUnitario = 35,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)",
                HorasSemanais = "5h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 9
            };
            var rub13 = new Rubrica
            {
                CodRubrica = "014",
                DescricaoRubrica = "Mens. GPT – Universitários",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "S",
                OrdemPrecario = 10,
                IVlrUnit = "S",
                ValorUnitario = 18,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "Sábado 10h00 às 13h00 (1x semana)",
                HorasSemanais = "3h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 10
            };
            //seed rubricas bolsa
            var rub14 = new Rubrica
            {
                CodRubrica = "015",
                DescricaoRubrica = "Mens. APZ 1 - Bolsa",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª e 5ª 17h45 às 18h30 (2x semana)",
                HorasSemanais = "1h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 1,
                DescontoId = "00"
            };
            var rub15 = new Rubrica
            {
                CodRubrica = "016",
                DescricaoRubrica = "Mens. APZ 2 - Bolsa",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª e 5ª 18h15 às 19h30  (2x semana)",
                HorasSemanais = "2h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 2,
                DescontoId = "00"
            };
            var rub16 = new Rubrica
            {
                CodRubrica = "017",
                DescricaoRubrica = "Mens. APZ 3 - Bolsa",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "3ª e 6ª 17h45 às 19h15  (2x semana)",
                HorasSemanais = "3h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 3,
                DescontoId = "00"
            };
            var rub17 = new Rubrica
            {
                CodRubrica = "018",
                DescricaoRubrica = "Mens. Acro 1 - Bolsa",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)",
                HorasSemanais = "7h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 4,
                DescontoId = "00"
            };
            var rub18 = new Rubrica
            {
                CodRubrica = "019",
                DescricaoRubrica = "Mens. Acro 2 - Bolsa",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)",
                HorasSemanais = "9h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 5,
                DescontoId = "00"
            };
            var rub19 = new Rubrica
            {
                CodRubrica = "020",
                DescricaoRubrica = "Mens. Acro 3 - Bolsa",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)",
                HorasSemanais = "12h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 6,
                DescontoId = "00"
            };
            var rub20 = new Rubrica
            {
                CodRubrica = "021",
                DescricaoRubrica = "Mens. TRAMP 1 - Bolsa",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)",
                HorasSemanais = "5h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 7,
                DescontoId = "00"
            };
            var rub21 = new Rubrica
            {
                CodRubrica = "022",
                DescricaoRubrica = "Mens. TRAMP 2 - Bolsa",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)",
                HorasSemanais = "9h15",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 8,
                DescontoId = "00"
            };
            var rub22 = new Rubrica
            {
                CodRubrica = "023",
                DescricaoRubrica = "Mens. GPT – Júnior - Bolsa",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)",
                HorasSemanais = "5h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 9,
                DescontoId = "00"
            };
            var rub23 = new Rubrica
            {
                CodRubrica = "024",
                DescricaoRubrica = "Mens. GPT – Univ. - Bolsa",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "Sábado 10h00 às 13h00 (1x semana)",
                HorasSemanais = "3h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 10,
                DescontoId = "00"
            };
            //seed rubricas Parentesco(1º familiar)
            var rub24 = new Rubrica
            {
                CodRubrica = "025",
                DescricaoRubrica = "Mens. APZ 1 - Par.(1º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)24.30,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª e 5ª 17h45 às 18h30 (2x semana)",
                HorasSemanais = "1h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 1,
                DescontoId = "01"
            };
            var rub25 = new Rubrica
            {
                CodRubrica = "026",
                DescricaoRubrica = "Mens. APZ 2 - Par.(1º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 27,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª e 5ª 18h15 às 19h30  (2x semana)",
                HorasSemanais = "2h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 2,
                DescontoId = "01"
            };
            var rub26 = new Rubrica
            {
                CodRubrica = "027",
                DescricaoRubrica = "Mens. APZ 3 - Par.(1º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)28.8,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "3ª e 6ª 17h45 às 19h15  (2x semana)",
                HorasSemanais = "3h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 3,
                DescontoId = "01"
            };
            var rub27 = new Rubrica
            {
                CodRubrica = "028",
                DescricaoRubrica = "Mens. Acro 1 - Par.(1º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 36,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)",
                HorasSemanais = "7h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 4,
                DescontoId = "01"
            };
            var rub28 = new Rubrica
            {
                CodRubrica = "029",
                DescricaoRubrica = "Mens. Acro 2 - Par.(1º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)40.50,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)",
                HorasSemanais = "9h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 5,
                DescontoId = "01"
            };
            var rub29 = new Rubrica
            {
                CodRubrica = "030",
                DescricaoRubrica = "Mens. Acro 3 - Par.(1º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)46.80,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)",
                HorasSemanais = "12h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 6,
                DescontoId = "01"
            };
            var rub30 = new Rubrica
            {
                CodRubrica = "031",
                DescricaoRubrica = "Mens. TRAMP 1 - Par.(1º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)32.40,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)",
                HorasSemanais = "5h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 7,
                DescontoId = "01"
            };
            var rub31 = new Rubrica
            {
                CodRubrica = "032",
                DescricaoRubrica = "Mens. TRAMP 2 - Par.(1º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)40.50,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)",
                HorasSemanais = "9h15",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 8,
                DescontoId = "01"
            };
            var rub32 = new Rubrica
            {
                CodRubrica = "033",
                DescricaoRubrica = "Mens. GPT – Júnior - Par.(1º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)31.50,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)",
                HorasSemanais = "5h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 9,
                DescontoId = "01"
            };
            var rub33 = new Rubrica
            {
                CodRubrica = "034",
                DescricaoRubrica = "Mens. GPT – Univ. - Par.(1º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)16.20,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "Sábado 10h00 às 13h00 (1x semana)",
                HorasSemanais = "3h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 10,
                DescontoId = "01"
            };
            //seed rubricas Parentesco(1º familiar)
            var rub34 = new Rubrica
            {
                CodRubrica = "035",
                DescricaoRubrica = "Mens. APZ 1 - Par.(2º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)22.95,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª e 5ª 17h45 às 18h30 (2x semana)",
                HorasSemanais = "1h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 1,
                DescontoId = "02"
            };
            var rub35 = new Rubrica
            {
                CodRubrica = "036",
                DescricaoRubrica = "Mens. APZ 2 - Par.(2º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)25.5,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª e 5ª 18h15 às 19h30  (2x semana)",
                HorasSemanais = "2h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 2,
                DescontoId = "02"
            };
            var rub36 = new Rubrica
            {
                CodRubrica = "037",
                DescricaoRubrica = "Mens. APZ 3 - Par.(2º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)27.2,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "3ª e 6ª 17h45 às 19h15  (2x semana)",
                HorasSemanais = "3h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 3,
                DescontoId = "02"
            };
            var rub37 = new Rubrica
            {
                CodRubrica = "038",
                DescricaoRubrica = "Mens. Acro 1 - Par.(2º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 34,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)",
                HorasSemanais = "7h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 4,
                DescontoId = "02"
            };
            var rub38 = new Rubrica
            {
                CodRubrica = "039",
                DescricaoRubrica = "Mens. Acro 2 - Par.(2º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)38.25,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)",
                HorasSemanais = "9h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 5,
                DescontoId = "02"
            };
            var rub39 = new Rubrica
            {
                CodRubrica = "040",
                DescricaoRubrica = "Mens. Acro 3 - Par.(2º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)44.20,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)",
                HorasSemanais = "12h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 6,
                DescontoId = "02"
            };
            var rub40 = new Rubrica
            {
                CodRubrica = "041",
                DescricaoRubrica = "Mens. TRAMP 1 - Par.(2º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)30.60,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)",
                HorasSemanais = "5h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 7,
                DescontoId = "02"
            };
            var rub41 = new Rubrica
            {
                CodRubrica = "042",
                DescricaoRubrica = "Mens. TRAMP 2 - Par.(2º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)38.25,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)",
                HorasSemanais = "9h15",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 8,
                DescontoId = "02"
            };
            var rub42 = new Rubrica
            {
                CodRubrica = "043",
                DescricaoRubrica = "Mens. GPT – Júnior - Par.(2º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)29.75,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)",
                HorasSemanais = "5h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 9,
                DescontoId = "02"
            };
            var rub43 = new Rubrica
            {
                CodRubrica = "044",
                DescricaoRubrica = "Mens. GPT – Univ. - Par.(2º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)15.30,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "Sábado 10h00 às 13h00 (1x semana)",
                HorasSemanais = "3h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 10,
                DescontoId = "02"
            };
            //seed rubricas Parentesco(3º familiar)
            var rub44 = new Rubrica
            {
                CodRubrica = "045",
                DescricaoRubrica = "Mens. APZ 1 - Par.(3º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)21.60,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª e 5ª 17h45 às 18h30 (2x semana)",
                HorasSemanais = "1h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 1,
                DescontoId = "03"
            };
            var rub45 = new Rubrica
            {
                CodRubrica = "046",
                DescricaoRubrica = "Mens. APZ 2 - Par.(3º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)24.00,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª e 5ª 18h15 às 19h30  (2x semana)",
                HorasSemanais = "2h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 2,
                DescontoId = "03"
            };
            var rub46 = new Rubrica
            {
                CodRubrica = "047",
                DescricaoRubrica = "Mens. APZ 3 - Par.(3º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)25.6,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "3ª e 6ª 17h45 às 19h15  (2x semana)",
                HorasSemanais = "3h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 3,
                DescontoId = "03"
            };
            var rub47 = new Rubrica
            {
                CodRubrica = "048",
                DescricaoRubrica = "Mens. Acro 1 - Par.(3º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 32,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "3ª, 4ª 17h45 às 20h00 e 6ª 17h45 às 20h15 (3x semana)",
                HorasSemanais = "7h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 4,
                DescontoId = "03"
            };
            var rub48 = new Rubrica
            {
                CodRubrica = "049",
                DescricaoRubrica = "Mens. Acro 2 - Par.(3º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 36,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "3ª, 4ª e 6ª 17h45 às 20h45  (3x semana)",
                HorasSemanais = "9h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 5,
                DescontoId = "03"
            };
            var rub49 = new Rubrica
            {
                CodRubrica = "050",
                DescricaoRubrica = "Mens. Acro 3 - Par.(3º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)41.60,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Stª Iria",
                Horario = "2ª, 3ª, 5ª 18h00 às 21h00 e Sábado 10h00 às 13h00  (4x semana)",
                HorasSemanais = "12h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 6,
                DescontoId = "03"
            };
            var rub50 = new Rubrica
            {
                CodRubrica = "051",
                DescricaoRubrica = "Mens. TRAMP 1 - Par.(3º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)28.80,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª, 5ª 18h00 às 19h45 e Sábado 11h00 às 13h00  (3x semana)",
                HorasSemanais = "5h30",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 7,
                DescontoId = "03"
            };
            var rub51 = new Rubrica
            {
                CodRubrica = "052",
                DescricaoRubrica = "Mens. TRAMP 2 - Par.(3º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 36,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "2ª 18h30 às 21h00 e 3ª, 4ª e 6ª 18h00 às 20h15  (4x semana)",
                HorasSemanais = "9h15",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 8,
                DescontoId = "03"
            };
            var rub52 = new Rubrica
            {
                CodRubrica = "053",
                DescricaoRubrica = "Mens. GPT – Júnior - Par.(3º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = 28,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "4ª 18h00 às 20h30 e Sábados 10h30 às 13h00  (2x semana)",
                HorasSemanais = "5h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 9,
                DescontoId = "03"
            };
            var rub53 = new Rubrica
            {
                CodRubrica = "054",
                DescricaoRubrica = "Mens. GPT – Univ. - Par.(3º)",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "S",
                ValorUnitario = (decimal?)14.40,
                IPagInscricao = "N",
                TipoRubrica = "G",
                LocalTreino = "Gualdim Pais",
                Horario = "Sábado 10h00 às 13h00 (1x semana)",
                HorasSemanais = "3h00",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue,
                ClasseId = 10,
                DescontoId = "03"
            };
            //rubrica pagamentos,devoluções e regularizações
            var rub54 = new Rubrica
            {
                CodRubrica = "055",
                DescricaoRubrica = "Pagamento",
                EstadoRubrica = "A",
                TipoMovimento = "C",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "N",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "P",
                LocalTreino = "",
                Horario = "",
                HorasSemanais = "",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var rub55 = new Rubrica
            {
                CodRubrica = "056",
                DescricaoRubrica = "Devolução",
                EstadoRubrica = "A",
                TipoMovimento = "C",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "N",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "D",
                LocalTreino = "",
                Horario = "",
                HorasSemanais = "",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var rub56 = new Rubrica
            {
                CodRubrica = "057",
                DescricaoRubrica = "Regularização Débito",
                EstadoRubrica = "A",
                TipoMovimento = "D",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "N",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "R",
                LocalTreino = "",
                Horario = "",
                HorasSemanais = "",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            var rub57 = new Rubrica
            {
                CodRubrica = "058",
                DescricaoRubrica = "Regularização Crédito",
                EstadoRubrica = "A",
                TipoMovimento = "C",
                IPrecario = "N",
                OrdemPrecario = null,
                IVlrUnit = "N",
                ValorUnitario = 0,
                IPagInscricao = "N",
                TipoRubrica = "R",
                LocalTreino = "",
                Horario = "",
                HorasSemanais = "",
                IdCriacao = "SEED",
                DataCriacao = DateTime.Now,
                IdModificacao = " ",
                DataModificacao = DateTime.MinValue
            };
            List<Rubrica> rubricas = new List<Rubrica>() 
            {
                rub,rub1,rub2,rub3,rub4,rub5,rub6,rub7,rub8,rub9,rub10,rub11,rub12,rub13,
                rub14,rub15,rub16,rub17,rub18,rub19,rub20,rub21,rub22,rub23,rub24,rub25,
                rub26,rub27,rub28,rub29,rub30,rub31,rub32,rub33,rub34,rub35,rub36,rub37,
                rub38,rub39,rub40,rub41,rub42,rub43,rub44,rub45,rub46,rub47,rub48,rub49,
                rub50,rub51,rub52,rub53,rub54,rub55,rub56,rub57
            };
            builder.Entity<Rubrica>().HasData(rubricas);
        }
    }
}
