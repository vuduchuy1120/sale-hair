using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class updateKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LengThicknessPrice",
                table: "LengThicknessPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LengthGridSizePrice",
                table: "LengthGridSizePrice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LengThicknessPrice",
                table: "LengThicknessPrice",
                columns: new[] { "LengthId", "ThicknessId", "IsWholeSale" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LengthGridSizePrice",
                table: "LengthGridSizePrice",
                columns: new[] { "LengthId", "GridSizeId", "IsWholeSale" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LengThicknessPrice",
                table: "LengThicknessPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LengthGridSizePrice",
                table: "LengthGridSizePrice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LengThicknessPrice",
                table: "LengThicknessPrice",
                columns: new[] { "LengthId", "ThicknessId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LengthGridSizePrice",
                table: "LengthGridSizePrice",
                columns: new[] { "LengthId", "GridSizeId" });
        }
    }
}
