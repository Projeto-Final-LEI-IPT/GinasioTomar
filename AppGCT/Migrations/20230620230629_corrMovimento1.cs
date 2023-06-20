using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class corrMovimento1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64a9bbc8-178f-4e12-9137-0423bb939c31", null, "Ginásio", "GINÁSIO" },
                    { "bd19c282-7d01-4b6b-b2f7-3ed5b9609aa2", null, "Administrador", "ADMINISTRADOR" },
                    { "e78e29bf-68bb-4062-83fa-b9079109e22e", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "aa0980bc-551c-43dc-8ed8-821e6b47db3b", 0, "b5992d50-c884-4197-bd48-64f03a9ffe3f", new DateTime(2023, 6, 21, 0, 6, 28, 981, DateTimeKind.Local).AddTicks(8316), new DateTime(2023, 6, 21, 0, 6, 28, 981, DateTimeKind.Local).AddTicks(8250), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 0, 6, 28, 981, DateTimeKind.Local).AddTicks(8323), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEG8FfH67CXPkfcf+Dq2u/k4xVqZFFCbQqfnjPZ3GjvvrxYPW7CtTOar/Mmj8Qdg2PA==", "999999999", false, "febdf8f6-2f72-4522-b581-01f308079943", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bd19c282-7d01-4b6b-b2f7-3ed5b9609aa2", "aa0980bc-551c-43dc-8ed8-821e6b47db3b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a9bbc8-178f-4e12-9137-0423bb939c31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e78e29bf-68bb-4062-83fa-b9079109e22e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd19c282-7d01-4b6b-b2f7-3ed5b9609aa2", "aa0980bc-551c-43dc-8ed8-821e6b47db3b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd19c282-7d01-4b6b-b2f7-3ed5b9609aa2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa0980bc-551c-43dc-8ed8-821e6b47db3b");

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
    }
}
