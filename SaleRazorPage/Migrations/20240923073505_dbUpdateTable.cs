using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class dbUpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorsThickness_Categories_CategoryId",
                table: "ColorsThickness");

            migrationBuilder.DropForeignKey(
                name: "FK_ColorsThickness_Thickness_ThicknessId",
                table: "ColorsThickness");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColorsThickness",
                table: "ColorsThickness");

            migrationBuilder.RenameTable(
                name: "ColorsThickness",
                newName: "CategoryThickness");

            migrationBuilder.RenameIndex(
                name: "IX_ColorsThickness_ThicknessId",
                table: "CategoryThickness",
                newName: "IX_CategoryThickness_ThicknessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryThickness",
                table: "CategoryThickness",
                columns: new[] { "CategoryId", "ThicknessId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryThickness_Categories_CategoryId",
                table: "CategoryThickness",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryThickness_Thickness_ThicknessId",
                table: "CategoryThickness",
                column: "ThicknessId",
                principalTable: "Thickness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryThickness_Categories_CategoryId",
                table: "CategoryThickness");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryThickness_Thickness_ThicknessId",
                table: "CategoryThickness");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryThickness",
                table: "CategoryThickness");

            migrationBuilder.RenameTable(
                name: "CategoryThickness",
                newName: "ColorsThickness");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryThickness_ThicknessId",
                table: "ColorsThickness",
                newName: "IX_ColorsThickness_ThicknessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColorsThickness",
                table: "ColorsThickness",
                columns: new[] { "CategoryId", "ThicknessId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ColorsThickness_Categories_CategoryId",
                table: "ColorsThickness",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColorsThickness_Thickness_ThicknessId",
                table: "ColorsThickness",
                column: "ThicknessId",
                principalTable: "Thickness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
