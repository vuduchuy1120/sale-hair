using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table_Sub_color : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_SubTypeHairs_SubTypeHairId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_SubTypeHairId",
                table: "Colors");

            migrationBuilder.CreateTable(
                name: "SubTypeColors",
                columns: table => new
                {
                    SubTypeHairId = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTypeColors", x => new { x.SubTypeHairId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_SubTypeColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubTypeColors_SubTypeHairs_SubTypeHairId",
                        column: x => x.SubTypeHairId,
                        principalTable: "SubTypeHairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTypeColors_ColorId",
                table: "SubTypeColors",
                column: "ColorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTypeColors");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_SubTypeHairId",
                table: "Colors",
                column: "SubTypeHairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_SubTypeHairs_SubTypeHairId",
                table: "Colors",
                column: "SubTypeHairId",
                principalTable: "SubTypeHairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
