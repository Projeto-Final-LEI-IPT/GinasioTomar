using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class _20230405_descontos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Desconto",
                columns: table => new
                {
                    CodDesconto = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DescDesconto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EstadoDesconto = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdModificacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desconto", x => x.CodDesconto);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ee3e60f-a2bc-4ca0-b90b-1e6ba494505c", null, "Administrador", "ADMINISTRADOR" },
                    { "52a6efef-ecf4-4f11-95e3-3b06e91019ba", null, "Ginásio", "GINÁSIO" },
                    { "84aa74a8-0ea0-477f-a5e2-6d22d9a40fbf", null, "Sócio", "SÓCIO" },
                    { "fabb12ca-a175-43ba-b8ad-db28798f90ea", null, "Anónimo", "ANÓNIMO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "f938cf8a-768d-4dcb-b9c9-d61a842c2c31", 0, "67e7c3e5-bd2e-4d50-a9e2-dc4ba708cc77", new DateTime(2023, 4, 5, 16, 59, 44, 844, DateTimeKind.Local).AddTicks(163), new DateTime(2023, 4, 5, 16, 59, 44, 844, DateTimeKind.Local).AddTicks(100), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 16, 59, 44, 844, DateTimeKind.Local).AddTicks(169), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEMb0VjZa8YQILiQTSRT0j1uRFbl2L3ciQ9P90c64tH27kQREuk1jfIvXnfbiDUtGMw==", "999999999", false, "253e3cb8-461e-4bf6-a3c7-e88d916b9e19", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4ee3e60f-a2bc-4ca0-b90b-1e6ba494505c", "f938cf8a-768d-4dcb-b9c9-d61a842c2c31" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desconto");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52a6efef-ecf4-4f11-95e3-3b06e91019ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84aa74a8-0ea0-477f-a5e2-6d22d9a40fbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fabb12ca-a175-43ba-b8ad-db28798f90ea");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ee3e60f-a2bc-4ca0-b90b-1e6ba494505c", "f938cf8a-768d-4dcb-b9c9-d61a842c2c31" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ee3e60f-a2bc-4ca0-b90b-1e6ba494505c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f938cf8a-768d-4dcb-b9c9-d61a842c2c31");

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
    }
}
