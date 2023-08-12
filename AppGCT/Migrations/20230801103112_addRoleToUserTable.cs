using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class addRoleToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d247230c-3c99-42e7-b0d4-81551bfa2acc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e982396c-c9f6-4a9e-888e-9b2f83e80071");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "068bae74-315d-4d88-9b27-189bd6bd79c1", "02bd1baf-f03f-4647-ae45-58f1270b1363" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068bae74-315d-4d88-9b27-189bd6bd79c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02bd1baf-f03f-4647-ae45-58f1270b1363");

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
                    { "048fb1a2-8e33-4d81-805d-823bf4744ab2", null, "Sócio", "SÓCIO" },
                    { "140a20ac-e8a6-4d34-b69d-d954f048882f", null, "Ginásio", "GINÁSIO" },
                    { "1ee157c5-51b6-4f37-99b1-a3f3c41060a4", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleAux", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "be685766-768a-4010-bd3c-8f4b19c399ff", 0, "3c555253-f733-4363-ba61-935396f328b0", new DateTime(2023, 8, 1, 11, 31, 12, 197, DateTimeKind.Local).AddTicks(243), new DateTime(2023, 8, 1, 11, 31, 12, 197, DateTimeKind.Local).AddTicks(172), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 1, 11, 31, 12, 197, DateTimeKind.Local).AddTicks(250), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEEFqKf1QE6rr2j5wvH7cdpvm0lv8RNeWiOHbXiNB+SIFYAeeubAkP3V4JJZjw6PtqQ==", "999999999", false, "Administrador", "459a361a-0b98-41ff-acb8-4d1fc25bd6d7", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1ee157c5-51b6-4f37-99b1-a3f3c41060a4", "be685766-768a-4010-bd3c-8f4b19c399ff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "048fb1a2-8e33-4d81-805d-823bf4744ab2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "140a20ac-e8a6-4d34-b69d-d954f048882f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1ee157c5-51b6-4f37-99b1-a3f3c41060a4", "be685766-768a-4010-bd3c-8f4b19c399ff" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ee157c5-51b6-4f37-99b1-a3f3c41060a4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be685766-768a-4010-bd3c-8f4b19c399ff");

            migrationBuilder.DropColumn(
                name: "RoleAux",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "068bae74-315d-4d88-9b27-189bd6bd79c1", null, "Administrador", "ADMINISTRADOR" },
                    { "d247230c-3c99-42e7-b0d4-81551bfa2acc", null, "Ginásio", "GINÁSIO" },
                    { "e982396c-c9f6-4a9e-888e-9b2f83e80071", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "02bd1baf-f03f-4647-ae45-58f1270b1363", 0, "ac26801c-a874-4631-8cda-e0c7ca4812f1", new DateTime(2023, 8, 1, 11, 10, 12, 311, DateTimeKind.Local).AddTicks(5456), new DateTime(2023, 8, 1, 11, 10, 12, 311, DateTimeKind.Local).AddTicks(5382), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 1, 11, 10, 12, 311, DateTimeKind.Local).AddTicks(5466), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEEx0dYmCClW0HkYpYlzWH6iClumRzJos4mU/ebsINPbJ7WrGEYo+0FnnnG+yUmFRcA==", "999999999", false, "f7ff1e64-6d9e-49bb-978b-a8768b075f34", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "068bae74-315d-4d88-9b27-189bd6bd79c1", "02bd1baf-f03f-4647-ae45-58f1270b1363" });
        }
    }
}
