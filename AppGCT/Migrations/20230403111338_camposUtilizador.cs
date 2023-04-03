using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class camposUtilizador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascim",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoUtilizador",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimoLogin",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAprovacao",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HtimestCriacao",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdCriacao",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HtimestModificacao",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdModificacao",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAprovacao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DataNascim",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EstadoUtilizador",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HtimestCriacao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HtimestModificacao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdCriacao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdModificacao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Morada",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UltimoLogin",
                table: "AspNetUsers");
        }
    }
}
