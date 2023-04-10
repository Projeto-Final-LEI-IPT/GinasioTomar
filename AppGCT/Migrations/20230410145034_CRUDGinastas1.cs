using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class CRUDGinastas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42c48747-fea9-4384-ab81-98cdee7cc9aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1b66054-4ca5-4c54-9b5b-e1ba0c5ce6a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed465d78-94b4-4220-b9c0-2eba88f6f3cf");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0f7cf19d-338b-4110-ae31-9ebb2a249092", "d93d8571-b093-463f-b89c-f90dd3682b4c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f7cf19d-338b-4110-ae31-9ebb2a249092");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d93d8571-b093-463f-b89c-f90dd3682b4c");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f7cf19d-338b-4110-ae31-9ebb2a249092", null, "Administrador", "ADMINISTRADOR" },
                    { "42c48747-fea9-4384-ab81-98cdee7cc9aa", null, "Ginásio", "GINÁSIO" },
                    { "a1b66054-4ca5-4c54-9b5b-e1ba0c5ce6a3", null, "Anónimo", "ANÓNIMO" },
                    { "ed465d78-94b4-4220-b9c0-2eba88f6f3cf", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "d93d8571-b093-463f-b89c-f90dd3682b4c", 0, "b2d1c1d4-2767-4447-8b4c-9dda0f1b5d87", new DateTime(2023, 4, 10, 15, 21, 58, 633, DateTimeKind.Local).AddTicks(8272), new DateTime(2023, 4, 10, 15, 21, 58, 633, DateTimeKind.Local).AddTicks(8135), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 15, 21, 58, 633, DateTimeKind.Local).AddTicks(8280), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAELy7p8W4HTV0YQBsCnsrYxD8iwFZVnzmZQM28riKJs4FWPpu0cVH03L3lgZzxhPCBg==", "999999999", false, "51c76046-d704-49c9-8cec-ad81a7d2316d", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0f7cf19d-338b-4110-ae31-9ebb2a249092", "d93d8571-b093-463f-b89c-f90dd3682b4c" });
        }
    }
}
