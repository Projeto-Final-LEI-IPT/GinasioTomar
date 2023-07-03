using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04ea650b-98f6-40d3-a268-32ec0216d545");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c39ed2-9e97-45f7-8899-46dbe07e4f4c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b6587191-f7c1-4d78-a56f-8e3329b04694", "55568b18-c1f3-449f-99bc-2cf52ceafe30" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6587191-f7c1-4d78-a56f-8e3329b04694");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55568b18-c1f3-449f-99bc-2cf52ceafe30");

            migrationBuilder.AddColumn<string>(
                name: "IPagInscricao",
                table: "Rubrica",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoRubrica",
                table: "Rubrica",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "057ce542-cc09-4275-b8c9-ded3f7d3108c", null, "Administrador", "ADMINISTRADOR" },
                    { "5ea9e1e8-067d-45dd-acde-df2f60123817", null, "Sócio", "SÓCIO" },
                    { "a698365d-eab2-48b0-a158-27b7b1ca1574", null, "Ginásio", "GINÁSIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "775b5112-c791-46b6-9457-e682e6ff39d4", 0, "a7b239a7-95e0-4e2f-9637-b02f991c591a", new DateTime(2023, 6, 27, 19, 10, 21, 281, DateTimeKind.Local).AddTicks(7594), new DateTime(2023, 6, 27, 19, 10, 21, 281, DateTimeKind.Local).AddTicks(7540), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 27, 19, 10, 21, 281, DateTimeKind.Local).AddTicks(7600), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAENbECvSRGesTdx2qOEoV23El4oVKACT0PrFww85bJAnZqWxg4YPzC/nUMWaUJVDRfw==", "999999999", false, "abfaa2b4-f74c-4057-bf4b-01caee669246", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "057ce542-cc09-4275-b8c9-ded3f7d3108c", "775b5112-c791-46b6-9457-e682e6ff39d4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ea9e1e8-067d-45dd-acde-df2f60123817");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a698365d-eab2-48b0-a158-27b7b1ca1574");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "057ce542-cc09-4275-b8c9-ded3f7d3108c", "775b5112-c791-46b6-9457-e682e6ff39d4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "057ce542-cc09-4275-b8c9-ded3f7d3108c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "775b5112-c791-46b6-9457-e682e6ff39d4");

            migrationBuilder.DropColumn(
                name: "IPagInscricao",
                table: "Rubrica");

            migrationBuilder.DropColumn(
                name: "TipoRubrica",
                table: "Rubrica");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04ea650b-98f6-40d3-a268-32ec0216d545", null, "Sócio", "SÓCIO" },
                    { "18c39ed2-9e97-45f7-8899-46dbe07e4f4c", null, "Ginásio", "GINÁSIO" },
                    { "b6587191-f7c1-4d78-a56f-8e3329b04694", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "55568b18-c1f3-449f-99bc-2cf52ceafe30", 0, "abf222e3-8bcd-4e74-aca3-cebf93dc96ea", new DateTime(2023, 6, 22, 20, 42, 44, 485, DateTimeKind.Local).AddTicks(1324), new DateTime(2023, 6, 22, 20, 42, 44, 485, DateTimeKind.Local).AddTicks(1257), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 22, 20, 42, 44, 485, DateTimeKind.Local).AddTicks(1332), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEPKyrDmvl7HHdnOYeLrnrC+/Q+50168Wmpd+f6k9ZT8F4I8IsvDBWSYTpnjFFZ/vcQ==", "999999999", false, "7d49353d-9e13-455b-969f-bc573de6d3c6", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b6587191-f7c1-4d78-a56f-8e3329b04694", "55568b18-c1f3-449f-99bc-2cf52ceafe30" });
        }
    }
}
