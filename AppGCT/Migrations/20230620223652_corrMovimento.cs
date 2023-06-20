using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class corrMovimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "436b1a3b-a304-4013-aa22-2fde3f1e8bf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7422acaf-769b-479c-b04c-cc7f46a89859");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "13ab1f50-b341-4bb3-b1a3-64b00a03c70e", "1ccb93bc-0ff5-4ca6-b989-0623be85d5a3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13ab1f50-b341-4bb3-b1a3-64b00a03c70e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ccb93bc-0ff5-4ca6-b989-0623be85d5a3");

            migrationBuilder.AlterColumn<string>(
                name: "NumNotaCredito",
                table: "Movimento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NumFatura",
                table: "Movimento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0308e14-48f4-4670-8ed1-e5699956605d", null, "Ginásio", "GINÁSIO" },
                    { "f97f4efb-2234-4b80-80c0-ccdbe3d1f6ba", null, "Sócio", "SÓCIO" },
                    { "f989926e-483d-447f-a171-a189d7ae126b", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "ff8bc49b-c5c9-4303-8f6a-ae5dae50c630", 0, "105168cd-60ca-43da-a1f4-daad375b8c2b", new DateTime(2023, 6, 20, 23, 36, 52, 24, DateTimeKind.Local).AddTicks(7922), new DateTime(2023, 6, 20, 23, 36, 52, 24, DateTimeKind.Local).AddTicks(7860), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 23, 36, 52, 24, DateTimeKind.Local).AddTicks(7930), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEIAttBZpIfnRYXx36/4G+LZQQg1BN8CWcop0TWquxDjPcZxLDoYM35xoJqSpn2VMJw==", "999999999", false, "a6eea154-a350-4fe0-9709-295eb3a86fc3", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f989926e-483d-447f-a171-a189d7ae126b", "ff8bc49b-c5c9-4303-8f6a-ae5dae50c630" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0308e14-48f4-4670-8ed1-e5699956605d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f97f4efb-2234-4b80-80c0-ccdbe3d1f6ba");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f989926e-483d-447f-a171-a189d7ae126b", "ff8bc49b-c5c9-4303-8f6a-ae5dae50c630" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f989926e-483d-447f-a171-a189d7ae126b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff8bc49b-c5c9-4303-8f6a-ae5dae50c630");

            migrationBuilder.AlterColumn<string>(
                name: "NumNotaCredito",
                table: "Movimento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumFatura",
                table: "Movimento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13ab1f50-b341-4bb3-b1a3-64b00a03c70e", null, "Administrador", "ADMINISTRADOR" },
                    { "436b1a3b-a304-4013-aa22-2fde3f1e8bf4", null, "Sócio", "SÓCIO" },
                    { "7422acaf-769b-479c-b04c-cc7f46a89859", null, "Ginásio", "GINÁSIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "1ccb93bc-0ff5-4ca6-b989-0623be85d5a3", 0, "86405d77-2664-43ca-9fd1-9db4ce6a9b6b", new DateTime(2023, 6, 19, 23, 12, 10, 950, DateTimeKind.Local).AddTicks(2369), new DateTime(2023, 6, 19, 23, 12, 10, 950, DateTimeKind.Local).AddTicks(2267), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 19, 23, 12, 10, 950, DateTimeKind.Local).AddTicks(2379), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEOgqvXR5Nq8qahu97BzMG5O07L5UIhJSFPGhLvN1zVFmWOY90MN5op0WOEaEWx0zmQ==", "999999999", false, "f14a177a-9133-4bb0-9fea-7c348cb1ff72", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "13ab1f50-b341-4bb3-b1a3-64b00a03c70e", "1ccb93bc-0ff5-4ca6-b989-0623be85d5a3" });
        }
    }
}
