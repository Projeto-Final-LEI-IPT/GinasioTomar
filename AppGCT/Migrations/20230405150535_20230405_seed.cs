using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class _20230405_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "046d17fc-380c-4346-b9c4-28e8d8a628e5", null, "Administrador", "ADMINISTRADOR" },
                    { "6d677246-85a0-4ed8-9531-126db08d97e0", null, "Sócio", "SÓCIO" },
                    { "cd8cfe96-1660-4405-8abc-31b2d6a75830", null, "Anónimo", "ANÓNIMO" },
                    { "da34dd83-91f9-4a6c-a5ed-74e8031f7887", null, "Ginásio", "GINÁSIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "c97c3f69-0907-4414-aafc-7e56c5f8967b", 0, "39fc3b85-119f-4099-ba7b-3140f97cc17e", new DateTime(2023, 4, 5, 16, 5, 35, 442, DateTimeKind.Local).AddTicks(7371), new DateTime(2023, 4, 5, 16, 5, 35, 442, DateTimeKind.Local).AddTicks(7321), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 16, 5, 35, 442, DateTimeKind.Local).AddTicks(7377), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEFVRRxvmWr/YhXZwj+iJFqBSOl3g/2uKibqLptijM6STJZzyKcleudy3i/9uvUUzhw==", "999999999", false, "aed522ec-d3bc-4825-b33a-82beda7a4739", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "046d17fc-380c-4346-b9c4-28e8d8a628e5", "c97c3f69-0907-4414-aafc-7e56c5f8967b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d677246-85a0-4ed8-9531-126db08d97e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd8cfe96-1660-4405-8abc-31b2d6a75830");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da34dd83-91f9-4a6c-a5ed-74e8031f7887");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "046d17fc-380c-4346-b9c4-28e8d8a628e5", "c97c3f69-0907-4414-aafc-7e56c5f8967b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "046d17fc-380c-4346-b9c4-28e8d8a628e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c97c3f69-0907-4414-aafc-7e56c5f8967b");
        }
    }
}
