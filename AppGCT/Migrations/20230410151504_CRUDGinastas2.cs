using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class CRUDGinastas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58acf1f9-466d-4650-a1b1-c567f49667e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "702a42a5-0ed2-4637-b0f7-680dc13e0eaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f868ed18-66c0-4b72-a3c7-b1ea04d0c25c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df7440da-b481-4be9-807f-223ac416d4b9", "90de3db5-5e96-4640-9fee-9d170bfeecb6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df7440da-b481-4be9-807f-223ac416d4b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90de3db5-5e96-4640-9fee-9d170bfeecb6");

            migrationBuilder.AlterColumn<string>(
                name: "IdadeAgosto",
                table: "Ginasta",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "IdadeAgosto",
                table: "Ginasta",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58acf1f9-466d-4650-a1b1-c567f49667e6", null, "Ginásio", "GINÁSIO" },
                    { "702a42a5-0ed2-4637-b0f7-680dc13e0eaf", null, "Anónimo", "ANÓNIMO" },
                    { "df7440da-b481-4be9-807f-223ac416d4b9", null, "Administrador", "ADMINISTRADOR" },
                    { "f868ed18-66c0-4b72-a3c7-b1ea04d0c25c", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "90de3db5-5e96-4640-9fee-9d170bfeecb6", 0, "87c8cf05-c08e-4d00-b393-5b4c5d096b7c", new DateTime(2023, 4, 10, 15, 50, 33, 444, DateTimeKind.Local).AddTicks(1969), new DateTime(2023, 4, 10, 15, 50, 33, 444, DateTimeKind.Local).AddTicks(1758), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 15, 50, 33, 444, DateTimeKind.Local).AddTicks(1983), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEBPv3GYDUcAYKtY+acm0D3hqRrxPFMgCbgzcniHL/4lUmpZfk7PlJA8zNVe0pafs/w==", "999999999", false, "a2571af2-cd8b-4906-8718-b989f9baca58", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "df7440da-b481-4be9-807f-223ac416d4b9", "90de3db5-5e96-4640-9fee-9d170bfeecb6" });
        }
    }
}
