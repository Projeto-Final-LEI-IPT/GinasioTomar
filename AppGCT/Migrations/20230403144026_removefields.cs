using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppGCT.Migrations
{
    /// <inheritdoc />
    public partial class removefields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtimestCriacao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HtimestModificacao",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HtimestCriacao",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HtimestModificacao",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }
    }
}
