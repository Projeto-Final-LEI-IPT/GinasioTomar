using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class teste3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e9561d6-d837-4131-8d46-d3a9a5c7f723");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f389778-2ec8-4c4d-ae4d-3e77ddc6fd5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a22523d-1be9-4a3b-9801-8a6062a862ab");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f3fba97-f483-45c2-86ff-d7ed02e497fa", "aa1deb63-5bd3-42cf-8932-0b0564c09259" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f3fba97-f483-45c2-86ff-d7ed02e497fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa1deb63-5bd3-42cf-8932-0b0564c09259");

            migrationBuilder.CreateTable(
                name: "Ginasta",
                columns: table => new
                {
                    IdGinasta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtNascim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdadeAgosto = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoGinasta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumCC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NISS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBolsa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IIrmaos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeIrmaos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIFEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prefixoTelemEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numTelemovelEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IGrauEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeEmerEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrauEmerEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrefixoTlmEmerEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTlmEmerEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailTlmEmerEE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdModificacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ginasta", x => x.IdGinasta);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00e202e4-1d40-47aa-a142-df575b8ea823", null, "Anónimo", "ANÓNIMO" },
                    { "07908457-9648-4d70-b283-dec0e0517be3", null, "Administrador", "ADMINISTRADOR" },
                    { "9b1b7664-b95c-40ea-92bb-c401589de2ce", null, "Ginásio", "GINÁSIO" },
                    { "fe4e232f-8a4d-4df0-a274-c03d863a17b3", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "6af0a34b-8b77-4121-8d19-0b8e1deb18c3", 0, "c89c4bdd-694a-49ab-8cff-1cfa19e8b6a8", new DateTime(2023, 4, 10, 14, 44, 7, 664, DateTimeKind.Local).AddTicks(1505), new DateTime(2023, 4, 10, 14, 44, 7, 664, DateTimeKind.Local).AddTicks(1314), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 14, 44, 7, 664, DateTimeKind.Local).AddTicks(1517), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEJdUz/I6jy1aE2ImSXgNfTRGaxCwPKnPFdkXPCGHdJFhD3UHlgmdOm3hWwVsizEVWQ==", "999999999", false, "cfbc7ee3-6164-4c99-b9ac-d28f11d01f85", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "07908457-9648-4d70-b283-dec0e0517be3", "6af0a34b-8b77-4121-8d19-0b8e1deb18c3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ginasta");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00e202e4-1d40-47aa-a142-df575b8ea823");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b1b7664-b95c-40ea-92bb-c401589de2ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe4e232f-8a4d-4df0-a274-c03d863a17b3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "07908457-9648-4d70-b283-dec0e0517be3", "6af0a34b-8b77-4121-8d19-0b8e1deb18c3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07908457-9648-4d70-b283-dec0e0517be3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6af0a34b-8b77-4121-8d19-0b8e1deb18c3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e9561d6-d837-4131-8d46-d3a9a5c7f723", null, "Sócio", "SÓCIO" },
                    { "6f389778-2ec8-4c4d-ae4d-3e77ddc6fd5e", null, "Anónimo", "ANÓNIMO" },
                    { "8a22523d-1be9-4a3b-9801-8a6062a862ab", null, "Ginásio", "GINÁSIO" },
                    { "9f3fba97-f483-45c2-86ff-d7ed02e497fa", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "aa1deb63-5bd3-42cf-8932-0b0564c09259", 0, "33f11bd0-ad9b-47cb-9cd5-762064d84f09", new DateTime(2023, 4, 10, 13, 30, 20, 865, DateTimeKind.Local).AddTicks(1528), new DateTime(2023, 4, 10, 13, 30, 20, 865, DateTimeKind.Local).AddTicks(1473), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 13, 30, 20, 865, DateTimeKind.Local).AddTicks(1537), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", "AQAAAAIAAYagAAAAEHZ0c4JCnUObdRe5BiTiPO9JQO7n//SKwZwVvySedeKRuq1JYniSnkuuVWyKPtx5pg==", "999999999", false, "ddf56d6d-4a89-41e3-96fb-dcfab840ffa5", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9f3fba97-f483-45c2-86ff-d7ed02e497fa", "aa1deb63-5bd3-42cf-8932-0b0564c09259" });
        }
    }
}
