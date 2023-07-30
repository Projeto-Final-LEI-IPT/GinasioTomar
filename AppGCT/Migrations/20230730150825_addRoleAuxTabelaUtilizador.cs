using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class addRoleAuxTabelaUtilizador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3d5c46-22a3-452d-9242-81ccd8b0a369");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4edae97-be85-4cb4-b54e-6b75c2908d59");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a8577095-5826-406f-aabe-3e2799a3305e", "0deb8a93-a871-4567-982b-ace99378c8f2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8577095-5826-406f-aabe-3e2799a3305e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0deb8a93-a871-4567-982b-ace99378c8f2");

            migrationBuilder.AddColumn<string>(
                name: "RoleAux",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "037c5d1d-b4f9-489b-a600-26406dd28888", null, "Sócio", "SÓCIO" },
                    { "29e30f04-b60b-4c16-b873-07c2aea52546", null, "Ginásio", "GINÁSIO" },
                    { "9e8a0fb7-9939-4051-9afc-46feed0948bb", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleAux", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "3976e568-3350-4e69-bc59-ca126caec498", 0, "38d91b63-239a-4b91-9ea3-ab10aa3a5d7b", new DateTime(2023, 7, 30, 16, 8, 25, 101, DateTimeKind.Local).AddTicks(3532), new DateTime(2023, 7, 30, 16, 8, 25, 101, DateTimeKind.Local).AddTicks(3465), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 30, 16, 8, 25, 101, DateTimeKind.Local).AddTicks(3540), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEI2DVRYvHLFn7N7KWHLSudQRHahgDGssJ0xTlEpP1c1/PAGlKwlZg5o9xuZuM5PEBQ==", "999999999", false, "Administrador", "ea33fa77-925c-4056-9483-e6ecf7f6add9", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9e8a0fb7-9939-4051-9afc-46feed0948bb", "3976e568-3350-4e69-bc59-ca126caec498" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037c5d1d-b4f9-489b-a600-26406dd28888");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29e30f04-b60b-4c16-b873-07c2aea52546");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9e8a0fb7-9939-4051-9afc-46feed0948bb", "3976e568-3350-4e69-bc59-ca126caec498" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e8a0fb7-9939-4051-9afc-46feed0948bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3976e568-3350-4e69-bc59-ca126caec498");

            migrationBuilder.DropColumn(
                name: "RoleAux",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a8577095-5826-406f-aabe-3e2799a3305e", null, "Administrador", "ADMINISTRADOR" },
                    { "ae3d5c46-22a3-452d-9242-81ccd8b0a369", null, "Ginásio", "GINÁSIO" },
                    { "c4edae97-be85-4cb4-b54e-6b75c2908d59", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "0deb8a93-a871-4567-982b-ace99378c8f2", 0, "b1365f90-fe04-4a2f-af59-5ef3e7c1f6c9", new DateTime(2023, 7, 24, 23, 35, 32, 34, DateTimeKind.Local).AddTicks(9182), new DateTime(2023, 7, 24, 23, 35, 32, 34, DateTimeKind.Local).AddTicks(9081), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 24, 23, 35, 32, 34, DateTimeKind.Local).AddTicks(9194), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEAiOGgmp2Wr1sB+2BHgS7grPcjV7qY3XXohe5KNg+HoHCMkSFfzhr0acJ+YQXlS7Cg==", "999999999", false, "14179428-8916-4946-b8fa-cfb4cfee840a", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a8577095-5826-406f-aabe-3e2799a3305e", "0deb8a93-a871-4567-982b-ace99378c8f2" });
        }
    }
}
