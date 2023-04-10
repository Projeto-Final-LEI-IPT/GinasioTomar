using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class datatype_Ginastas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11718778-365e-4623-8f04-acea33ef470a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2aecef7f-8dff-41cb-b073-6aac34432552");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56545da1-206a-4dfa-92a6-9faf7d71e187");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f6e44c51-aebc-4d79-b636-000351c5099e", "eecf9c1f-e9ba-4e25-b548-2a7d96b9205c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6e44c51-aebc-4d79-b636-000351c5099e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eecf9c1f-e9ba-4e25-b548-2a7d96b9205c");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11718778-365e-4623-8f04-acea33ef470a", null, "Ginásio", "GINÁSIO" },
                    { "2aecef7f-8dff-41cb-b073-6aac34432552", null, "Sócio", "SÓCIO" },
                    { "56545da1-206a-4dfa-92a6-9faf7d71e187", null, "Anónimo", "ANÓNIMO" },
                    { "f6e44c51-aebc-4d79-b636-000351c5099e", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "eecf9c1f-e9ba-4e25-b548-2a7d96b9205c", 0, "1e1755d7-dfeb-4e33-9b45-64bc4e7512f9", new DateTime(2023, 4, 10, 16, 15, 3, 619, DateTimeKind.Local).AddTicks(4545), new DateTime(2023, 4, 10, 16, 15, 3, 619, DateTimeKind.Local).AddTicks(4263), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 16, 15, 3, 619, DateTimeKind.Local).AddTicks(4574), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEPmEERyvhrvjYhVvDE4swoea28z3manLY+JQg5LERMPAbc2sK9taMrPO2yK3JmsQ1g==", "999999999", false, "9440ffcc-ae23-484a-8f14-8cf194716049", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f6e44c51-aebc-4d79-b636-000351c5099e", "eecf9c1f-e9ba-4e25-b548-2a7d96b9205c" });
        }
    }
}
