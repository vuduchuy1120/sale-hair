using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class dbUpdateTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeHairs_Categories_CategoryId",
                table: "TypeHairs");

            migrationBuilder.DropTable(
                name: "SubTypeColors");

            migrationBuilder.DropIndex(
                name: "IX_TypeHairs_CategoryId",
                table: "TypeHairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTypeHairs",
                table: "SubTypeHairs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TypeHairs");

            migrationBuilder.RenameColumn(
                name: "NameUnAccent",
                table: "SubTypeHairs",
                newName: "SubTypeNameUnAccent");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SubTypeHairs",
                newName: "SubTypeName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubTypeHairs",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SubTypeHairs_Id",
                table: "SubTypeHairs",
                newName: "IX_SubTypeHairs_CategoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "SubTypeHairs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "OrderDetails",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "OrderDetails",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubTypeHairCategoryId",
                table: "OrderDetails",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubTypeHairColorId",
                table: "OrderDetails",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTypeHairSubTypeName",
                table: "OrderDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubTypeHairTypeHairId",
                table: "OrderDetails",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTypeName",
                table: "OrderDetails",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeHairId",
                table: "OrderDetails",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTypeHairs",
                table: "SubTypeHairs",
                columns: new[] { "ColorId", "CategoryId", "TypeHairId", "SubTypeName" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CategoryId",
                table: "OrderDetails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ColorId",
                table: "OrderDetails",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SubTypeHairColorId_SubTypeHairCategoryId_SubTy~",
                table: "OrderDetails",
                columns: new[] { "SubTypeHairColorId", "SubTypeHairCategoryId", "SubTypeHairTypeHairId", "SubTypeHairSubTypeName" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_TypeHairId",
                table: "OrderDetails",
                column: "TypeHairId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Categories_CategoryId",
                table: "OrderDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Colors_ColorId",
                table: "OrderDetails",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_SubTypeHairs_SubTypeHairColorId_SubTypeHairCat~",
                table: "OrderDetails",
                columns: new[] { "SubTypeHairColorId", "SubTypeHairCategoryId", "SubTypeHairTypeHairId", "SubTypeHairSubTypeName" },
                principalTable: "SubTypeHairs",
                principalColumns: new[] { "ColorId", "CategoryId", "TypeHairId", "SubTypeName" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_TypeHairs_TypeHairId",
                table: "OrderDetails",
                column: "TypeHairId",
                principalTable: "TypeHairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTypeHairs_Categories_CategoryId",
                table: "SubTypeHairs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTypeHairs_Colors_ColorId",
                table: "SubTypeHairs",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Categories_CategoryId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Colors_ColorId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_SubTypeHairs_SubTypeHairColorId_SubTypeHairCat~",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_TypeHairs_TypeHairId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTypeHairs_Categories_CategoryId",
                table: "SubTypeHairs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTypeHairs_Colors_ColorId",
                table: "SubTypeHairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTypeHairs",
                table: "SubTypeHairs");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_CategoryId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ColorId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_SubTypeHairColorId_SubTypeHairCategoryId_SubTy~",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_TypeHairId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "SubTypeHairs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SubTypeHairCategoryId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SubTypeHairColorId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SubTypeHairSubTypeName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SubTypeHairTypeHairId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SubTypeName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "TypeHairId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "SubTypeNameUnAccent",
                table: "SubTypeHairs",
                newName: "NameUnAccent");

            migrationBuilder.RenameColumn(
                name: "SubTypeName",
                table: "SubTypeHairs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "SubTypeHairs",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SubTypeHairs_CategoryId",
                table: "SubTypeHairs",
                newName: "IX_SubTypeHairs_Id");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "TypeHairs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTypeHairs",
                table: "SubTypeHairs",
                column: "Id");

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
                name: "IX_TypeHairs_CategoryId",
                table: "TypeHairs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTypeColors_ColorId",
                table: "SubTypeColors",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeHairs_Categories_CategoryId",
                table: "TypeHairs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
