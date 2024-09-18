using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class remove_GuidId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTypeHairId",
                table: "Colors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubTypeHairId",
                table: "Colors",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
