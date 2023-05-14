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
                keyValue: "34019671-0a33-4664-827c-1cf4efb599a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bebf1ae-b952-4526-9ad0-2ed7d9e87afb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffb97690-2002-4a53-bd82-ed736f5469d9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "19a9c3d5-ee4d-4a3c-88fa-3222833beb04", "a603988f-f72b-4fcb-b55b-c58ddbba50b2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19a9c3d5-ee4d-4a3c-88fa-3222833beb04");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a603988f-f72b-4fcb-b55b-c58ddbba50b2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a60b26e-ccb8-4d9b-a1ac-1aadc7444cd7", null, "Sócio", "SÓCIO" },
                    { "1f67f4b4-e582-4fd5-aa78-7b814912f58e", null, "Ginásio", "GINÁSIO" },
                    { "3f0486d1-171d-44c0-b01d-2ec6dbb113fe", null, "Anónimo", "ANÓNIMO" },
                    { "d5fa3149-1001-499a-8fb2-baca9c983997", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "6d19bbbf-9010-44a0-8f98-48fa3517d246", 0, "009acecf-1f53-4a6d-a21c-c837b138849d", new DateTime(2023, 5, 14, 15, 17, 17, 418, DateTimeKind.Local).AddTicks(8424), new DateTime(2023, 5, 14, 15, 17, 17, 418, DateTimeKind.Local).AddTicks(8360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 14, 15, 17, 17, 418, DateTimeKind.Local).AddTicks(8435), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEDA0B6wd3kJJcAso8TJaBudaIBtrFaxJE5Fw1opUe3fJdlzniVo0ik8efoCduSvWag==", "999999999", false, "ac0e0849-8c87-484a-816c-9375ad580c78", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d5fa3149-1001-499a-8fb2-baca9c983997", "6d19bbbf-9010-44a0-8f98-48fa3517d246" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a60b26e-ccb8-4d9b-a1ac-1aadc7444cd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f67f4b4-e582-4fd5-aa78-7b814912f58e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f0486d1-171d-44c0-b01d-2ec6dbb113fe");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d5fa3149-1001-499a-8fb2-baca9c983997", "6d19bbbf-9010-44a0-8f98-48fa3517d246" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5fa3149-1001-499a-8fb2-baca9c983997");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d19bbbf-9010-44a0-8f98-48fa3517d246");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19a9c3d5-ee4d-4a3c-88fa-3222833beb04", null, "Administrador", "ADMINISTRADOR" },
                    { "34019671-0a33-4664-827c-1cf4efb599a6", null, "Ginásio", "GINÁSIO" },
                    { "5bebf1ae-b952-4526-9ad0-2ed7d9e87afb", null, "Anónimo", "ANÓNIMO" },
                    { "ffb97690-2002-4a53-bd82-ed736f5469d9", null, "Sócio", "SÓCIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataAprovacao", "DataCriacao", "DataModificacao", "DataNascim", "Email", "EmailConfirmed", "EstadoUtilizador", "IdCriacao", "IdModificacao", "LockoutEnabled", "LockoutEnd", "Morada", "NIF", "Nome", "NormalizedEmail", "NormalizedUserName", "NumSocio", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoLogin", "UserName" },
                values: new object[] { "a603988f-f72b-4fcb-b55b-c58ddbba50b2", 0, "d61963e9-c595-4f36-8349-b44a791d6859", new DateTime(2023, 5, 14, 12, 39, 22, 758, DateTimeKind.Local).AddTicks(1148), new DateTime(2023, 5, 14, 12, 39, 22, 758, DateTimeKind.Local).AddTicks(1092), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 14, 12, 39, 22, 758, DateTimeKind.Local).AddTicks(1156), "admin@localhost", true, "A", "SEED", " ", false, null, "Ginásio Clube de Tomar", "999999999", "Administrador", "ADMIN@LOCALHOST", "ADMIN@LOCALHOST", " ", "AQAAAAIAAYagAAAAEG5VLwaNCLeFnf1kLpWbxpw1K/PojC1H82+WtyNBkkGkt8OLPGUtnidh5miZeBo2Sw==", "999999999", false, "3babc934-9b40-4707-90a5-f586fdaccfe3", false, null, "admin@localhost" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "19a9c3d5-ee4d-4a3c-88fa-3222833beb04", "a603988f-f72b-4fcb-b55b-c58ddbba50b2" });
        }
    }
}
