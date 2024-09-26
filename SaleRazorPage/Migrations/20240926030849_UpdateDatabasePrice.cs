using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabasePrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameUnAccent",
                table: "Lengths");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GridSizes");

            migrationBuilder.DropColumn(
                name: "NameUnAccent",
                table: "GridSizes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Lengths",
                newName: "Inch");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "GridSizes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LengthGridSizePrice",
                columns: table => new
                {
                    LengthId = table.Column<Guid>(type: "uuid", nullable: false),
                    GridSizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsWholeSale = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LengthGridSizePrice", x => new { x.LengthId, x.GridSizeId });
                    table.ForeignKey(
                        name: "FK_LengthGridSizePrice_GridSizes_GridSizeId",
                        column: x => x.GridSizeId,
                        principalTable: "GridSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LengthGridSizePrice_Lengths_LengthId",
                        column: x => x.LengthId,
                        principalTable: "Lengths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LengThicknessPrice",
                columns: table => new
                {
                    LengthId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThicknessId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsWholeSale = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LengThicknessPrice", x => new { x.LengthId, x.ThicknessId });
                    table.ForeignKey(
                        name: "FK_LengThicknessPrice_Lengths_LengthId",
                        column: x => x.LengthId,
                        principalTable: "Lengths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LengThicknessPrice_Thickness_ThicknessId",
                        column: x => x.ThicknessId,
                        principalTable: "Thickness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LengthGridSizePrice_GridSizeId",
                table: "LengthGridSizePrice",
                column: "GridSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_LengThicknessPrice_ThicknessId",
                table: "LengThicknessPrice",
                column: "ThicknessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LengthGridSizePrice");

            migrationBuilder.DropTable(
                name: "LengThicknessPrice");

            migrationBuilder.RenameColumn(
                name: "Inch",
                table: "Lengths",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "NameUnAccent",
                table: "Lengths",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "GridSizes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GridSizes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameUnAccent",
                table: "GridSizes",
                type: "text",
                nullable: true);
        }
    }
}
