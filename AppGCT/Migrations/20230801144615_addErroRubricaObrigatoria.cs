using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class addErroRubricaObrigatoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07811f89-1b44-4371-a9d1-ae6613cdf208", null, "Sócio", "SÓCIO" },
                    { "77b58475-272e-4ef4-ac72-c8318375a6b7", null, "Ginásio", "GINÁSIO" },
                    { "7f11615e-2242-4cb4-9cf6-ceaee7180e39", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleAux", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "9e917e58-563a-43c4-9f26-abd6aca1deee", 0, "643098e2-8800-45cd-913c-a91337a9e962", new DateTime(2023, 8, 1, 15, 46, 14, 124, DateTimeKind.Local).AddTicks(3109), new DateTime(2023, 8, 1, 15, 46, 14, 124, DateTimeKind.Local).AddTicks(3027), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 1, 15, 46, 14, 124, DateTimeKind.Local).AddTicks(3119), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEMUydp5MmsXxa+vaU6lpnJyCqZcCD/4d+SL5swD+P4XbHY0xPbFDeLt+Y/54Ewu+ug==", "999999999", false, "Administrador", "d305a138-8d45-4bda-abc8-583e0d936800", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7f11615e-2242-4cb4-9cf6-ceaee7180e39", "9e917e58-563a-43c4-9f26-abd6aca1deee" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07811f89-1b44-4371-a9d1-ae6613cdf208");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77b58475-272e-4ef4-ac72-c8318375a6b7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7f11615e-2242-4cb4-9cf6-ceaee7180e39", "9e917e58-563a-43c4-9f26-abd6aca1deee" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f11615e-2242-4cb4-9cf6-ceaee7180e39");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e917e58-563a-43c4-9f26-abd6aca1deee");

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
    }
}
