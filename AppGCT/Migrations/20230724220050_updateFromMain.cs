using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class updateFromMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "324a48cc-7fef-4c27-bdb6-08d870b96333");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d202fabb-4afe-40e3-9582-f6d7ce95f23a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "664bac2b-a11e-4628-b6b9-34852b004119", "9f66fcdd-4b5e-4d90-b073-341819c90ace" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "664bac2b-a11e-4628-b6b9-34852b004119");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f66fcdd-4b5e-4d90-b073-341819c90ace");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "324a48cc-7fef-4c27-bdb6-08d870b96333", null, "Sócio", "SÓCIO" },
                    { "664bac2b-a11e-4628-b6b9-34852b004119", null, "Administrador", "ADMINISTRADOR" },
                    { "d202fabb-4afe-40e3-9582-f6d7ce95f23a", null, "Ginásio", "GINÁSIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "9f66fcdd-4b5e-4d90-b073-341819c90ace", 0, "13669fee-09a9-4c95-8276-29ca4a6132ff", new DateTime(2023, 7, 24, 22, 53, 25, 697, DateTimeKind.Local).AddTicks(2430), new DateTime(2023, 7, 24, 22, 53, 25, 697, DateTimeKind.Local).AddTicks(2352), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 24, 22, 53, 25, 697, DateTimeKind.Local).AddTicks(2436), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEBNRXo/9cZOxr7HNapA0MVv36jn2O/VkpXsAZ53Cfyh8iGdbZdoJDJB7CgF29u7nPg==", "999999999", false, "1e5dffd6-db14-4b55-ac19-cec40ea91ecf", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "664bac2b-a11e-4628-b6b9-34852b004119", "9f66fcdd-4b5e-4d90-b073-341819c90ace" });
        }
    }
}
