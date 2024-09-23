using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class dbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorRequests");

            migrationBuilder.CreateTable(
                name: "GridColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameUnAccent = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GridColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GridSizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameUnAccent = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GridSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lengths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameUnAccent = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lengths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeliveryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Quantity = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thickness",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameUnAccent = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thickness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thornes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameUnAccent = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thornes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorsThickness",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThicknessId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorsThickness", x => new { x.CategoryId, x.ThicknessId });
                    table.ForeignKey(
                        name: "FK_ColorsThickness_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorsThickness_Thickness_ThicknessId",
                        column: x => x.ThicknessId,
                        principalTable: "Thickness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThorneId = table.Column<Guid>(type: "uuid", nullable: false),
                    LengthId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThicknessId = table.Column<Guid>(type: "uuid", nullable: false),
                    GridSizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    SetHairRequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    GridColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: true),
                    IsBorder = table.Column<bool>(type: "boolean", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.SetHairRequestId, x.GridColorId, x.ThorneId, x.LengthId, x.GridSizeId, x.ThicknessId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_GridColors_GridColorId",
                        column: x => x.GridColorId,
                        principalTable: "GridColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_GridSizes_GridSizeId",
                        column: x => x.GridSizeId,
                        principalTable: "GridSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_HairRequests_SetHairRequestId",
                        column: x => x.SetHairRequestId,
                        principalTable: "HairRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Lengths_LengthId",
                        column: x => x.LengthId,
                        principalTable: "Lengths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Thickness_ThicknessId",
                        column: x => x.ThicknessId,
                        principalTable: "Thickness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Thornes_ThorneId",
                        column: x => x.ThorneId,
                        principalTable: "Thornes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorsThickness_ThicknessId",
                table: "ColorsThickness",
                column: "ThicknessId");

            migrationBuilder.CreateIndex(
                name: "IX_GridColors_Id",
                table: "GridColors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GridSizes_Id",
                table: "GridSizes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lengths_Id",
                table: "Lengths",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_GridColorId",
                table: "OrderDetails",
                column: "GridColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_GridSizeId",
                table: "OrderDetails",
                column: "GridSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LengthId",
                table: "OrderDetails",
                column: "LengthId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SetHairRequestId",
                table: "OrderDetails",
                column: "SetHairRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ThicknessId",
                table: "OrderDetails",
                column: "ThicknessId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ThorneId",
                table: "OrderDetails",
                column: "ThorneId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Thickness_Id",
                table: "Thickness",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Thornes_Id",
                table: "Thornes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorsThickness");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "GridColors");

            migrationBuilder.DropTable(
                name: "GridSizes");

            migrationBuilder.DropTable(
                name: "Lengths");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Thickness");

            migrationBuilder.DropTable(
                name: "Thornes");

            migrationBuilder.CreateTable(
                name: "ColorRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SetHairRequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameUnAccent = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorRequests_HairRequests_SetHairRequestId",
                        column: x => x.SetHairRequestId,
                        principalTable: "HairRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorRequests_Id",
                table: "ColorRequests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ColorRequests_SetHairRequestId",
                table: "ColorRequests",
                column: "SetHairRequestId");
        }
    }
}
