using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class numsocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f1b76e2-5326-419c-900a-193b5d9883a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33752b1f-3913-4e05-98ab-a061d05f3062");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7895df62-6c09-405a-a4dd-f0467853d51f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "36136b64-ace9-424d-9ba0-48ca4ca4c37c", "108039b6-c08e-4bc3-8c4e-ed1567b65e77" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36136b64-ace9-424d-9ba0-48ca4ca4c37c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "108039b6-c08e-4bc3-8c4e-ed1567b65e77");

            migrationBuilder.AddColumn<string>(
                name: "NumSocio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "003ed600-811b-4d02-bf77-b45fbad4822a", null, "Sócio", "SÓCIO" },
                    { "1e6d3af8-62f8-4e00-b31e-e194d7c838e4", null, "Administrador", "ADMINISTRADOR" },
                    { "38fc1c18-187b-4122-a3ea-4767381bea68", null, "Anónimo", "ANÓNIMO" },
                    { "6464654d-00fb-408b-8dcd-899c0695c39f", null, "Ginásio", "GINÁSIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "21dbadf1-5160-4b41-b7e4-dd214f49eded", 0, "36312739-db83-497b-9900-53259b81d11a", new DateTime(2023, 4, 10, 17, 25, 0, 621, DateTimeKind.Local).AddTicks(4548), new DateTime(2023, 4, 10, 17, 25, 0, 621, DateTimeKind.Local).AddTicks(4331), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 17, 25, 0, 621, DateTimeKind.Local).AddTicks(4675), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEPsTMqqGg2emcknhsyGi7crORvGHodAEPh2HpTU/KZdg6Lx2p7UvHQLSJbKXamJzKQ==", "999999999", false, "9889db06-4e34-4b5f-8f1c-4b9dbe801447", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1e6d3af8-62f8-4e00-b31e-e194d7c838e4", "21dbadf1-5160-4b41-b7e4-dd214f49eded" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "003ed600-811b-4d02-bf77-b45fbad4822a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38fc1c18-187b-4122-a3ea-4767381bea68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6464654d-00fb-408b-8dcd-899c0695c39f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e6d3af8-62f8-4e00-b31e-e194d7c838e4", "21dbadf1-5160-4b41-b7e4-dd214f49eded" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e6d3af8-62f8-4e00-b31e-e194d7c838e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21dbadf1-5160-4b41-b7e4-dd214f49eded");

            migrationBuilder.DropColumn(
                name: "NumSocio",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f1b76e2-5326-419c-900a-193b5d9883a4", null, "Anónimo", "ANÓNIMO" },
                    { "33752b1f-3913-4e05-98ab-a061d05f3062", null, "Ginásio", "GINÁSIO" },
                    { "36136b64-ace9-424d-9ba0-48ca4ca4c37c", null, "Administrador", "ADMINISTRADOR" },
                    { "7895df62-6c09-405a-a4dd-f0467853d51f", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "108039b6-c08e-4bc3-8c4e-ed1567b65e77", 0, "4b752bc7-1043-4d02-9a9f-49fd764ba8ea", new DateTime(2023, 4, 10, 16, 32, 36, 291, DateTimeKind.Local).AddTicks(3741), new DateTime(2023, 4, 10, 16, 32, 36, 291, DateTimeKind.Local).AddTicks(3688), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 16, 32, 36, 291, DateTimeKind.Local).AddTicks(3748), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEA6dL9Ca1SOszMRChWjkLHrejFXlO5OjYIiIjOUuGj/sKdSwGJZ9Ventm8l56+2JWg==", "999999999", false, "dc57d3f2-a816-4702-b99a-41098fdf37a0", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "36136b64-ace9-424d-9ba0-48ca4ca4c37c", "108039b6-c08e-4bc3-8c4e-ed1567b65e77" });
        }
    }
}
