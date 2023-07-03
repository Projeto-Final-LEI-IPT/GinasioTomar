using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class planomensalidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a086450-30dc-4098-a555-fa73362d09fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee9c5be8-4a14-408f-9154-339434fe5101");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "823bd384-ef82-4770-8403-0c1639438fe3", "5a7f9ba9-ce97-4c6e-a7d6-9bc4333b0ca7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "823bd384-ef82-4770-8403-0c1639438fe3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a7f9ba9-ce97-4c6e-a7d6-9bc4333b0ca7");

            migrationBuilder.CreateTable(
                name: "PlanoMensalidade",
                columns: table => new
                {
                    IdPlanoM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataMensalidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMensalidade = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdModificacao = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    EpocaId = table.Column<int>(type: "int", nullable: false),
                    GinastaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoMensalidade", x => x.IdPlanoM);
                    table.ForeignKey(
                        name: "FK_PlanoMensalidade_Epoca_EpocaId",
                        column: x => x.EpocaId,
                        principalTable: "Epoca",
                        principalColumn: "IdEpoca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanoMensalidade_Ginasta_GinastaId",
                        column: x => x.GinastaId,
                        principalTable: "Ginasta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PlanoMensalidade_EpocaId",
                table: "PlanoMensalidade",
                column: "EpocaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoMensalidade_GinastaId",
                table: "PlanoMensalidade",
                column: "GinastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanoMensalidade");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a086450-30dc-4098-a555-fa73362d09fa", null, "Ginásio", "GINÁSIO" },
                    { "823bd384-ef82-4770-8403-0c1639438fe3", null, "Administrador", "ADMINISTRADOR" },
                    { "ee9c5be8-4a14-408f-9154-339434fe5101", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "5a7f9ba9-ce97-4c6e-a7d6-9bc4333b0ca7", 0, "49906231-19c8-443a-9775-87f3ec1b03f2", new DateTime(2023, 6, 1, 21, 36, 30, 120, DateTimeKind.Local).AddTicks(8986), new DateTime(2023, 6, 1, 21, 36, 30, 120, DateTimeKind.Local).AddTicks(8926), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 21, 36, 30, 120, DateTimeKind.Local).AddTicks(8993), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEHF7pZNRmArVybraqBaTMWeDpjjh6oepks7Amccx1NXgSiDNaLjADrFAyppciAWm7A==", "999999999", false, "0bca4e21-d580-436d-ad6c-4c51aec2b0cb", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "823bd384-ef82-4770-8403-0c1639438fe3", "5a7f9ba9-ce97-4c6e-a7d6-9bc4333b0ca7" });
        }
    }
}
