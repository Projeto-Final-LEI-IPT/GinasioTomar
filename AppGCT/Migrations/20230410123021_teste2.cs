using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class teste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52a6efef-ecf4-4f11-95e3-3b06e91019ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84aa74a8-0ea0-477f-a5e2-6d22d9a40fbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fabb12ca-a175-43ba-b8ad-db28798f90ea");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ee3e60f-a2bc-4ca0-b90b-1e6ba494505c", "f938cf8a-768d-4dcb-b9c9-d61a842c2c31" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ee3e60f-a2bc-4ca0-b90b-1e6ba494505c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f938cf8a-768d-4dcb-b9c9-d61a842c2c31");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e9561d6-d837-4131-8d46-d3a9a5c7f723", null, "Sócio", "SÓCIO" },
                    { "6f389778-2ec8-4c4d-ae4d-3e77ddc6fd5e", null, "Anónimo", "ANÓNIMO" },
                    { "8a22523d-1be9-4a3b-9801-8a6062a862ab", null, "Ginásio", "GINÁSIO" },
                    { "9f3fba97-f483-45c2-86ff-d7ed02e497fa", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "aa1deb63-5bd3-42cf-8932-0b0564c09259", 0, "33f11bd0-ad9b-47cb-9cd5-762064d84f09", new DateTime(2023, 4, 10, 13, 30, 20, 865, DateTimeKind.Local).AddTicks(1528), new DateTime(2023, 4, 10, 13, 30, 20, 865, DateTimeKind.Local).AddTicks(1473), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 13, 30, 20, 865, DateTimeKind.Local).AddTicks(1537), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEHZ0c4JCnUObdRe5BiTiPO9JQO7n//SKwZwVvySedeKRuq1JYniSnkuuVWyKPtx5pg==", "999999999", false, "ddf56d6d-4a89-41e3-96fb-dcfab840ffa5", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9f3fba97-f483-45c2-86ff-d7ed02e497fa", "aa1deb63-5bd3-42cf-8932-0b0564c09259" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e9561d6-d837-4131-8d46-d3a9a5c7f723");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f389778-2ec8-4c4d-ae4d-3e77ddc6fd5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a22523d-1be9-4a3b-9801-8a6062a862ab");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f3fba97-f483-45c2-86ff-d7ed02e497fa", "aa1deb63-5bd3-42cf-8932-0b0564c09259" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f3fba97-f483-45c2-86ff-d7ed02e497fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa1deb63-5bd3-42cf-8932-0b0564c09259");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ee3e60f-a2bc-4ca0-b90b-1e6ba494505c", null, "Administrador", "ADMINISTRADOR" },
                    { "52a6efef-ecf4-4f11-95e3-3b06e91019ba", null, "Ginásio", "GINÁSIO" },
                    { "84aa74a8-0ea0-477f-a5e2-6d22d9a40fbf", null, "Sócio", "SÓCIO" },
                    { "fabb12ca-a175-43ba-b8ad-db28798f90ea", null, "Anónimo", "ANÓNIMO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "f938cf8a-768d-4dcb-b9c9-d61a842c2c31", 0, "67e7c3e5-bd2e-4d50-a9e2-dc4ba708cc77", new DateTime(2023, 4, 5, 16, 59, 44, 844, DateTimeKind.Local).AddTicks(163), new DateTime(2023, 4, 5, 16, 59, 44, 844, DateTimeKind.Local).AddTicks(100), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 16, 59, 44, 844, DateTimeKind.Local).AddTicks(169), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEMb0VjZa8YQILiQTSRT0j1uRFbl2L3ciQ9P90c64tH27kQREuk1jfIvXnfbiDUtGMw==", "999999999", false, "253e3cb8-461e-4bf6-a3c7-e88d916b9e19", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4ee3e60f-a2bc-4ca0-b90b-1e6ba494505c", "f938cf8a-768d-4dcb-b9c9-d61a842c2c31" });
        }
    }
}
