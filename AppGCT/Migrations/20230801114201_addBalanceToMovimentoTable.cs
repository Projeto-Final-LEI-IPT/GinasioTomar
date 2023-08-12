using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class addBalanceToMovimentoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "NumNotaCredito",
                table: "Movimento",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumFatura",
                table: "Movimento",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DesRubrica",
                table: "Movimento",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MSaldo",
                table: "Movimento",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Movimento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fd24eb6-691d-4a2c-adb7-8041d615ceea", null, "Ginásio", "GINÁSIO" },
                    { "31a79109-7f2e-4820-b852-44ba3a6b5a24", null, "Sócio", "SÓCIO" },
                    { "97e95f46-ab8d-454a-a9ef-54952edf4917", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleAux", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "e1783c75-cb83-4dbb-a2d5-afe661ee57c7", 0, "7a59b302-1560-423d-b190-831bb788f64c", new DateTime(2023, 8, 1, 12, 42, 0, 503, DateTimeKind.Local).AddTicks(3569), new DateTime(2023, 8, 1, 12, 42, 0, 503, DateTimeKind.Local).AddTicks(3500), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 1, 12, 42, 0, 503, DateTimeKind.Local).AddTicks(3575), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAECNwLo7msH4WRv1OoxG1mQQbwC2uL6cxx74Xe0NuV8p7pNJf2sGudvVwXXxbkNObtg==", "999999999", false, "Administrador", "63938ab0-001c-4230-8a3c-9ad8326a1596", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "97e95f46-ab8d-454a-a9ef-54952edf4917", "e1783c75-cb83-4dbb-a2d5-afe661ee57c7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fd24eb6-691d-4a2c-adb7-8041d615ceea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31a79109-7f2e-4820-b852-44ba3a6b5a24");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "97e95f46-ab8d-454a-a9ef-54952edf4917", "e1783c75-cb83-4dbb-a2d5-afe661ee57c7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97e95f46-ab8d-454a-a9ef-54952edf4917");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1783c75-cb83-4dbb-a2d5-afe661ee57c7");

            migrationBuilder.DropColumn(
                name: "MSaldo",
                table: "Movimento");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Movimento");

            migrationBuilder.AlterColumn<string>(
                name: "NumNotaCredito",
                table: "Movimento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumFatura",
                table: "Movimento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DesRubrica",
                table: "Movimento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

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
    }
}
