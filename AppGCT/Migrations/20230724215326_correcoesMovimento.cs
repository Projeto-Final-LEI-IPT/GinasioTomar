using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class correcoesMovimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f1f460a-7adc-4829-85bb-b0844a69e5fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8340a32-dd43-4e09-9290-0e40f17d9a9e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "69fc38c4-6ad6-4678-905c-6e13ce8baf2c", "8863372e-421f-45c5-8d91-a52056597fb7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69fc38c4-6ad6-4678-905c-6e13ce8baf2c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8863372e-421f-45c5-8d91-a52056597fb7");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoRubrica",
                table: "Rubrica",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "MSaldo",
                table: "Movimento");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Movimento");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoRubrica",
                table: "Rubrica",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

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
                    { "4f1f460a-7adc-4829-85bb-b0844a69e5fa", null, "Ginásio", "GINÁSIO" },
                    { "69fc38c4-6ad6-4678-905c-6e13ce8baf2c", null, "Administrador", "ADMINISTRADOR" },
                    { "a8340a32-dd43-4e09-9290-0e40f17d9a9e", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "8863372e-421f-45c5-8d91-a52056597fb7", 0, "40ec7396-036b-4eb6-a888-2acb54c9ef5d", new DateTime(2023, 7, 23, 21, 53, 21, 634, DateTimeKind.Local).AddTicks(5533), new DateTime(2023, 7, 23, 21, 53, 21, 634, DateTimeKind.Local).AddTicks(5425), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 23, 21, 53, 21, 634, DateTimeKind.Local).AddTicks(5548), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAENqHShVxPj5LswigH91cMGt6Qr6o1rwJpsZpr/Orfl72na5PWgrEwpUmaYmueaefzw==", "999999999", false, "2fcc4fbc-692f-4bbb-981b-387c91894ae7", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "69fc38c4-6ad6-4678-905c-6e13ce8baf2c", "8863372e-421f-45c5-8d91-a52056597fb7" });
        }
    }
}
