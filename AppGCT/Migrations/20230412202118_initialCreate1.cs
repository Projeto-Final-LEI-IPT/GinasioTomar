using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0505c415-dff0-4bbe-ae27-f47b97ba3906");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24a8d7f6-9f2f-4976-9da5-b57d60fe383b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f94ca29-d5e8-4c31-af27-4c52f5aa98c4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b80330f-7616-4dd8-9c10-17704b223a9d", "feff1c78-11d6-41c1-9728-075ef0e9a28d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b80330f-7616-4dd8-9c10-17704b223a9d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "feff1c78-11d6-41c1-9728-075ef0e9a28d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11a64a71-6256-4208-84c3-2b05fc1fc8e2", null, "Sócio", "SÓCIO" },
                    { "26142e96-21be-4945-b84b-ef2b42d3e458", null, "Anónimo", "ANÓNIMO" },
                    { "46ed7130-f0ae-45d3-b5a1-c0d663102cfe", null, "Administrador", "ADMINISTRADOR" },
                    { "b0cf72e1-362b-476a-bb20-ac552576c5ac", null, "Ginásio", "GINÁSIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "01e21036-e4a0-48b1-9892-fe387e580e31", 0, "4b85c0df-2192-460d-8f42-a416e3a59b09", new DateTime(2023, 4, 12, 21, 21, 17, 916, DateTimeKind.Local).AddTicks(9460), new DateTime(2023, 4, 12, 21, 21, 17, 916, DateTimeKind.Local).AddTicks(9390), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 12, 21, 21, 17, 916, DateTimeKind.Local).AddTicks(9503), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEGKf6owXz/yZ4qdaeCJiyCtPA7Sy0TUuj62saq5VQJBoxZSfytN0VyD2TR9MnyCq6Q==", "999999999", false, "1fb4ed61-1711-435c-9900-e349557e3334", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "46ed7130-f0ae-45d3-b5a1-c0d663102cfe", "01e21036-e4a0-48b1-9892-fe387e580e31" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11a64a71-6256-4208-84c3-2b05fc1fc8e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26142e96-21be-4945-b84b-ef2b42d3e458");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0cf72e1-362b-476a-bb20-ac552576c5ac");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46ed7130-f0ae-45d3-b5a1-c0d663102cfe", "01e21036-e4a0-48b1-9892-fe387e580e31" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46ed7130-f0ae-45d3-b5a1-c0d663102cfe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01e21036-e4a0-48b1-9892-fe387e580e31");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0505c415-dff0-4bbe-ae27-f47b97ba3906", null, "Sócio", "SÓCIO" },
                    { "24a8d7f6-9f2f-4976-9da5-b57d60fe383b", null, "Anónimo", "ANÓNIMO" },
                    { "4f94ca29-d5e8-4c31-af27-4c52f5aa98c4", null, "Ginásio", "GINÁSIO" },
                    { "9b80330f-7616-4dd8-9c10-17704b223a9d", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "feff1c78-11d6-41c1-9728-075ef0e9a28d", 0, "c33723ba-196f-4ad1-bc8b-b8b19faf5552", new DateTime(2023, 4, 12, 21, 4, 27, 362, DateTimeKind.Local).AddTicks(849), new DateTime(2023, 4, 12, 21, 4, 27, 362, DateTimeKind.Local).AddTicks(791), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 12, 21, 4, 27, 362, DateTimeKind.Local).AddTicks(853), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEPeHo1xJS4dZAa6G0S66JKHUKJEcC7X+kXzHLObV1++Heg9H/7OG27FEUJBMzNb6Cw==", "999999999", false, "af7422dd-055b-4ec5-873e-2a75768d9cd2", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9b80330f-7616-4dd8-9c10-17704b223a9d", "feff1c78-11d6-41c1-9728-075ef0e9a28d" });
        }
    }
}
