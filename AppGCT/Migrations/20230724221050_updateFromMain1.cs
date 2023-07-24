using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class updateFromMain1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8860868f-6c74-431d-8eaf-468197fe0225");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cccf3d35-894b-499a-a974-9037ef47ca88");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "637c0df9-ec33-41ed-81a4-72d209001d28", "931b487d-31c0-428c-bf3c-c57ada64efb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "637c0df9-ec33-41ed-81a4-72d209001d28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "931b487d-31c0-428c-bf3c-c57ada64efb9");

            migrationBuilder.CreateTable(
                name: "Saldo",
                columns: table => new
                {
                    IdSocio = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    MSaldo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldo", x => x.IdSocio);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "391cdd38-8831-49ef-b689-51f1f664c66a", null, "Ginásio", "GINÁSIO" },
                    { "815eaa8f-eb65-4d4a-bdad-68af1e813e30", null, "Sócio", "SÓCIO" },
                    { "a1401b26-2594-4882-a6ec-4d6b93a54253", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "270f475e-47ce-426c-8ce3-0fdbf626beb5", 0, "14be7187-0d56-4ae8-9288-6b6ea07a5aa1", new DateTime(2023, 7, 24, 23, 10, 49, 926, DateTimeKind.Local).AddTicks(5435), new DateTime(2023, 7, 24, 23, 10, 49, 926, DateTimeKind.Local).AddTicks(5268), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 24, 23, 10, 49, 926, DateTimeKind.Local).AddTicks(5466), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEM5517aZ+Z/uG6ixKO1+87bO/b/iMgpWJ07Zsq11pXIYbSRXNwgzK7AIJFI7T8I+Dw==", "999999999", false, "b4797be9-5658-4099-ac65-213d623e64e6", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a1401b26-2594-4882-a6ec-4d6b93a54253", "270f475e-47ce-426c-8ce3-0fdbf626beb5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saldo");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391cdd38-8831-49ef-b689-51f1f664c66a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "815eaa8f-eb65-4d4a-bdad-68af1e813e30");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a1401b26-2594-4882-a6ec-4d6b93a54253", "270f475e-47ce-426c-8ce3-0fdbf626beb5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1401b26-2594-4882-a6ec-4d6b93a54253");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "270f475e-47ce-426c-8ce3-0fdbf626beb5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "637c0df9-ec33-41ed-81a4-72d209001d28", null, "Administrador", "ADMINISTRADOR" },
                    { "8860868f-6c74-431d-8eaf-468197fe0225", null, "Ginásio", "GINÁSIO" },
                    { "cccf3d35-894b-499a-a974-9037ef47ca88", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "931b487d-31c0-428c-bf3c-c57ada64efb9", 0, "d271bb97-7753-4fea-80c3-5434cc86c892", new DateTime(2023, 7, 24, 23, 0, 50, 145, DateTimeKind.Local).AddTicks(5017), new DateTime(2023, 7, 24, 23, 0, 50, 145, DateTimeKind.Local).AddTicks(4942), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 24, 23, 0, 50, 145, DateTimeKind.Local).AddTicks(5029), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAENrz1RI26PRKcsZtNHOuqLKP2Juxl8EKyx7ZNJTsxlEwSOb/rr03K4OreaoOeHxUHQ==", "999999999", false, "26d83e30-44d5-43b8-8ae8-5d8df9643eca", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "637c0df9-ec33-41ed-81a4-72d209001d28", "931b487d-31c0-428c-bf3c-c57ada64efb9" });
        }
    }
}
