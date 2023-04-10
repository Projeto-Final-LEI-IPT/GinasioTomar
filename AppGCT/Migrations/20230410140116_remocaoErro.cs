using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class remocaoErro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00e202e4-1d40-47aa-a142-df575b8ea823");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b1b7664-b95c-40ea-92bb-c401589de2ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe4e232f-8a4d-4df0-a274-c03d863a17b3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "07908457-9648-4d70-b283-dec0e0517be3", "6af0a34b-8b77-4121-8d19-0b8e1deb18c3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07908457-9648-4d70-b283-dec0e0517be3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6af0a34b-8b77-4121-8d19-0b8e1deb18c3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dd8b706-cb86-46a1-bc3c-181ab21f0fc2", null, "Administrador", "ADMINISTRADOR" },
                    { "a30dfd5d-ab83-4b84-9a89-82fb41009009", null, "Ginásio", "GINÁSIO" },
                    { "ba726e9d-4eae-43aa-bc4d-7b199863a629", null, "Anónimo", "ANÓNIMO" },
                    { "f07b3158-7179-4ee5-b4b2-91b1926b0b6e", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "a18e51aa-ffcf-4ac4-befd-78be8d3febdb", 0, "85cc8efa-dbaf-4f5b-9acc-0bd338a8860e", new DateTime(2023, 4, 10, 15, 1, 15, 577, DateTimeKind.Local).AddTicks(4852), new DateTime(2023, 4, 10, 15, 1, 15, 577, DateTimeKind.Local).AddTicks(4732), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 15, 1, 15, 577, DateTimeKind.Local).AddTicks(4858), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEP80rX75uOS7R80viejXHE9pN50ScBxnCpBbUwdG064F+e03GrrRUGEGpt4ZW4R+eA==", "999999999", false, "6565819e-8aac-4edb-8fdf-ebc95048760c", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0dd8b706-cb86-46a1-bc3c-181ab21f0fc2", "a18e51aa-ffcf-4ac4-befd-78be8d3febdb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a30dfd5d-ab83-4b84-9a89-82fb41009009");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba726e9d-4eae-43aa-bc4d-7b199863a629");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f07b3158-7179-4ee5-b4b2-91b1926b0b6e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0dd8b706-cb86-46a1-bc3c-181ab21f0fc2", "a18e51aa-ffcf-4ac4-befd-78be8d3febdb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dd8b706-cb86-46a1-bc3c-181ab21f0fc2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18e51aa-ffcf-4ac4-befd-78be8d3febdb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00e202e4-1d40-47aa-a142-df575b8ea823", null, "Anónimo", "ANÓNIMO" },
                    { "07908457-9648-4d70-b283-dec0e0517be3", null, "Administrador", "ADMINISTRADOR" },
                    { "9b1b7664-b95c-40ea-92bb-c401589de2ce", null, "Ginásio", "GINÁSIO" },
                    { "fe4e232f-8a4d-4df0-a274-c03d863a17b3", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "6af0a34b-8b77-4121-8d19-0b8e1deb18c3", 0, "c89c4bdd-694a-49ab-8cff-1cfa19e8b6a8", new DateTime(2023, 4, 10, 14, 44, 7, 664, DateTimeKind.Local).AddTicks(1505), new DateTime(2023, 4, 10, 14, 44, 7, 664, DateTimeKind.Local).AddTicks(1314), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 14, 44, 7, 664, DateTimeKind.Local).AddTicks(1517), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEJdUz/I6jy1aE2ImSXgNfTRGaxCwPKnPFdkXPCGHdJFhD3UHlgmdOm3hWwVsizEVWQ==", "999999999", false, "cfbc7ee3-6164-4c99-b9ac-d28f11d01f85", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "07908457-9648-4d70-b283-dec0e0517be3", "6af0a34b-8b77-4121-8d19-0b8e1deb18c3" });
        }
    }
}
