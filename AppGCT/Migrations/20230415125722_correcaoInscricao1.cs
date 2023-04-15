using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class correcaoInscricao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2f58fd7-6ed7-418e-995c-e4890082a75d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1ba3c81-6b83-4aea-9353-6cab7ae4575a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2c5ae2f-c69d-470d-ab22-9f42512c1184");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46184e00-2a02-4e08-8d87-9a7503f25c59", "5100f9bf-9679-4638-b396-7ee550a70ea8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46184e00-2a02-4e08-8d87-9a7503f25c59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5100f9bf-9679-4638-b396-7ee550a70ea8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ecd6ab6-f6f4-4b6f-a152-714c14661fd0", null, "Anónimo", "ANÓNIMO" },
                    { "1a3d1a77-1942-427d-a5e9-14f83c33f79a", null, "Administrador", "ADMINISTRADOR" },
                    { "63e575b7-bb8b-41ad-a1c2-a8847e2e1e53", null, "Ginásio", "GINÁSIO" },
                    { "ab39ece8-1f6c-457a-96ce-65093c1b464b", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "ccfa486e-eafa-4fb4-a36c-941d4a28dd5d", 0, "a8b95c53-d7dd-4a8f-a5cd-16d234e0dcdf", new DateTime(2023, 4, 15, 13, 57, 21, 640, DateTimeKind.Local).AddTicks(1629), new DateTime(2023, 4, 15, 13, 57, 21, 640, DateTimeKind.Local).AddTicks(1577), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 15, 13, 57, 21, 640, DateTimeKind.Local).AddTicks(1635), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEKze5oU/6GS/y88tdyQmxNmS0Qtgm0U2c8T8JaJmLbtMyD1GvuwlV+vPDIS5Y82IuA==", "999999999", false, "5eb78ff9-4317-42d5-9774-324cf8da452e", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1a3d1a77-1942-427d-a5e9-14f83c33f79a", "ccfa486e-eafa-4fb4-a36c-941d4a28dd5d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ecd6ab6-f6f4-4b6f-a152-714c14661fd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63e575b7-bb8b-41ad-a1c2-a8847e2e1e53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab39ece8-1f6c-457a-96ce-65093c1b464b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a3d1a77-1942-427d-a5e9-14f83c33f79a", "ccfa486e-eafa-4fb4-a36c-941d4a28dd5d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a3d1a77-1942-427d-a5e9-14f83c33f79a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccfa486e-eafa-4fb4-a36c-941d4a28dd5d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46184e00-2a02-4e08-8d87-9a7503f25c59", null, "Administrador", "ADMINISTRADOR" },
                    { "a2f58fd7-6ed7-418e-995c-e4890082a75d", null, "Anónimo", "ANÓNIMO" },
                    { "b1ba3c81-6b83-4aea-9353-6cab7ae4575a", null, "Sócio", "SÓCIO" },
                    { "f2c5ae2f-c69d-470d-ab22-9f42512c1184", null, "Ginásio", "GINÁSIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "5100f9bf-9679-4638-b396-7ee550a70ea8", 0, "d32ab5d6-6648-4628-815e-48b9fec75bda", new DateTime(2023, 4, 15, 13, 42, 28, 244, DateTimeKind.Local).AddTicks(3234), new DateTime(2023, 4, 15, 13, 42, 28, 244, DateTimeKind.Local).AddTicks(3181), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 15, 13, 42, 28, 244, DateTimeKind.Local).AddTicks(3239), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEB9n44hE3MoNQOROcMWi/qqq4OSP7AsurgFrhFSnM+f8KScXLD9utVrpTTMe6l3PPg==", "999999999", false, "02fdd687-8342-47e4-93d9-2627757d7b9b", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "46184e00-2a02-4e08-8d87-9a7503f25c59", "5100f9bf-9679-4638-b396-7ee550a70ea8" });
        }
    }
}
