using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class correcaoInscricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28a6b357-6d89-4e14-aab9-727af9744fde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69d6ac14-3154-4365-a2e1-683e725c3f46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71000b1d-5e61-44d0-8759-dd6a64a64d7b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3c57eaa-2938-4f35-b791-eb68db0e7ee7", "b5ee057f-3821-481c-924f-6e0a5d6c18ac" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3c57eaa-2938-4f35-b791-eb68db0e7ee7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5ee057f-3821-481c-924f-6e0a5d6c18ac");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Inscricao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "Inscricao",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescAlergias",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtConsentimento",
                table: "Inscricao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DtExamMed",
                table: "Inscricao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DtFicFGP",
                table: "Inscricao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInscricao",
                table: "Inscricao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IAntiInflam",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IConsentimento",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IExamMed",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IFicFGP",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IFotos",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IIbuprofeno",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ILeituraObrig",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IPagamInscricao",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IParacetamol",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ISeguro",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdCriacao",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdModificacao",
                table: "Inscricao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46184e00-2a02-4e08-8d87-9a7503f25c59", null, "Administrador", "ADMINISTRADOR" },
                    { "a2f58fd7-6ed7-418e-995c-e4890082a75d", null, "Anónimo", "ANÓNIMO" },
                    { "b1ba3c81-6b83-4aea-9353-6cab7ae4575a", null, "Sócio", "SÓCIO" },
                    { "f2c5ae2f-c69d-470d-ab22-9f42512c1184", null, "Ginásio", "GINÁSIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "5100f9bf-9679-4638-b396-7ee550a70ea8", 0, "d32ab5d6-6648-4628-815e-48b9fec75bda", new DateTime(2023, 4, 15, 13, 42, 28, 244, DateTimeKind.Local).AddTicks(3234), new DateTime(2023, 4, 15, 13, 42, 28, 244, DateTimeKind.Local).AddTicks(3181), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 15, 13, 42, 28, 244, DateTimeKind.Local).AddTicks(3239), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEB9n44hE3MoNQOROcMWi/qqq4OSP7AsurgFrhFSnM+f8KScXLD9utVrpTTMe6l3PPg==", "999999999", false, "02fdd687-8342-47e4-93d9-2627757d7b9b", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "46184e00-2a02-4e08-8d87-9a7503f25c59", "5100f9bf-9679-4638-b396-7ee550a70ea8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2f58fd7-6ed7-418e-995c-e4890082a75d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1ba3c81-6b83-4aea-9353-6cab7ae4575a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2c5ae2f-c69d-470d-ab22-9f42512c1184");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46184e00-2a02-4e08-8d87-9a7503f25c59", "5100f9bf-9679-4638-b396-7ee550a70ea8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46184e00-2a02-4e08-8d87-9a7503f25c59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5100f9bf-9679-4638-b396-7ee550a70ea8");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "DescAlergias",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "DtConsentimento",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "DtExamMed",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "DtFicFGP",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "DtInscricao",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "IAntiInflam",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "IConsentimento",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "IExamMed",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "IFicFGP",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "IFotos",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "IIbuprofeno",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "ILeituraObrig",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "IPagamInscricao",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "IParacetamol",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "ISeguro",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "IdCriacao",
                table: "Inscricao");

            migrationBuilder.DropColumn(
                name: "IdModificacao",
                table: "Inscricao");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28a6b357-6d89-4e14-aab9-727af9744fde", null, "Anónimo", "ANÓNIMO" },
                    { "69d6ac14-3154-4365-a2e1-683e725c3f46", null, "Sócio", "SÓCIO" },
                    { "71000b1d-5e61-44d0-8759-dd6a64a64d7b", null, "Ginásio", "GINÁSIO" },
                    { "a3c57eaa-2938-4f35-b791-eb68db0e7ee7", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "b5ee057f-3821-481c-924f-6e0a5d6c18ac", 0, "3f3860d6-0a7c-40fe-9013-4243efdb8c71", new DateTime(2023, 4, 13, 15, 49, 30, 233, DateTimeKind.Local).AddTicks(4006), new DateTime(2023, 4, 13, 15, 49, 30, 233, DateTimeKind.Local).AddTicks(3954), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 13, 15, 49, 30, 233, DateTimeKind.Local).AddTicks(4010), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAELXcM9+4Se9szE2OZLjbeGY7FphT00unZ0agq3OHKyKCGseo9QdqbHrkFlhAHfCjcA==", "999999999", false, "5c4bfa10-e406-4e2c-8ff1-a4b203889c7f", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a3c57eaa-2938-4f35-b791-eb68db0e7ee7", "b5ee057f-3821-481c-924f-6e0a5d6c18ac" });
        }
    }
}
