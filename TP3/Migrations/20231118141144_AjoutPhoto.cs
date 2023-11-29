using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class AjoutPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Movies",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Movies");
        }
    }
}
