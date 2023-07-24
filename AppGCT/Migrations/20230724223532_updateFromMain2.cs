using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class updateFromMain2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<decimal>(
                name: "MSaldo",
                table: "Movimento",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "MSaldo",
                table: "Movimento",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

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
    }
}
