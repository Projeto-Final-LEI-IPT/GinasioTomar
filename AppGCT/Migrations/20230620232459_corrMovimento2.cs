using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class corrMovimento2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a9bbc8-178f-4e12-9137-0423bb939c31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e78e29bf-68bb-4062-83fa-b9079109e22e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd19c282-7d01-4b6b-b2f7-3ed5b9609aa2", "aa0980bc-551c-43dc-8ed8-821e6b47db3b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd19c282-7d01-4b6b-b2f7-3ed5b9609aa2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa0980bc-551c-43dc-8ed8-821e6b47db3b");

            migrationBuilder.AlterColumn<string>(
                name: "DesRubrica",
                table: "Movimento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bf3892a5-b4a2-46b2-b4c4-60df00f36039", null, "Ginásio", "GINÁSIO" },
                    { "cb7bb9d7-c10e-417e-a279-687e433ac546", null, "Sócio", "SÓCIO" },
                    { "df4d1cc3-dd57-4901-b2cd-8d4e1e118e36", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "cf0da355-eb8b-4a33-8629-66cd1baeb97a", 0, "7310da4f-eafe-4190-bc12-cd9d55824d93", new DateTime(2023, 6, 21, 0, 24, 59, 40, DateTimeKind.Local).AddTicks(191), new DateTime(2023, 6, 21, 0, 24, 59, 40, DateTimeKind.Local).AddTicks(126), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 24, 59, 40, DateTimeKind.Local).AddTicks(200), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAELlYnVQMKX8DbHbzd0E3NufUmJ7f3ro43Jql+wEd9ZY/Y8QPM5AhndqLZAOTTPX3GQ==", "999999999", false, "d27dccd2-5064-45a9-95e4-924498e4cbc6", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "df4d1cc3-dd57-4901-b2cd-8d4e1e118e36", "cf0da355-eb8b-4a33-8629-66cd1baeb97a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf3892a5-b4a2-46b2-b4c4-60df00f36039");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb7bb9d7-c10e-417e-a279-687e433ac546");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df4d1cc3-dd57-4901-b2cd-8d4e1e118e36", "cf0da355-eb8b-4a33-8629-66cd1baeb97a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df4d1cc3-dd57-4901-b2cd-8d4e1e118e36");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf0da355-eb8b-4a33-8629-66cd1baeb97a");

            migrationBuilder.AlterColumn<string>(
                name: "DesRubrica",
                table: "Movimento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64a9bbc8-178f-4e12-9137-0423bb939c31", null, "Ginásio", "GINÁSIO" },
                    { "bd19c282-7d01-4b6b-b2f7-3ed5b9609aa2", null, "Administrador", "ADMINISTRADOR" },
                    { "e78e29bf-68bb-4062-83fa-b9079109e22e", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "aa0980bc-551c-43dc-8ed8-821e6b47db3b", 0, "b5992d50-c884-4197-bd48-64f03a9ffe3f", new DateTime(2023, 6, 21, 0, 6, 28, 981, DateTimeKind.Local).AddTicks(8316), new DateTime(2023, 6, 21, 0, 6, 28, 981, DateTimeKind.Local).AddTicks(8250), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 6, 28, 981, DateTimeKind.Local).AddTicks(8323), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEG8FfH67CXPkfcf+Dq2u/k4xVqZFFCbQqfnjPZ3GjvvrxYPW7CtTOar/Mmj8Qdg2PA==", "999999999", false, "febdf8f6-2f72-4522-b581-01f308079943", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bd19c282-7d01-4b6b-b2f7-3ed5b9609aa2", "aa0980bc-551c-43dc-8ed8-821e6b47db3b" });
        }
    }
}
