using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    FacebookLink = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    Ward = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HairRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HairRequests_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeHairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameUnAccent = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeHairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeHairs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SetHairRequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameUnAccent = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "SubTypeHairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeHairId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameUnAccent = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTypeHairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTypeHairs_TypeHairs_TypeHairId",
                        column: x => x.TypeHairId,
                        principalTable: "TypeHairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubTypeHairId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameUnAccent = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_SubTypeHairs_SubTypeHairId",
                        column: x => x.SubTypeHairId,
                        principalTable: "SubTypeHairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ColorRequests_Id",
                table: "ColorRequests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ColorRequests_SetHairRequestId",
                table: "ColorRequests",
                column: "SetHairRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_Id",
                table: "Colors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_SubTypeHairId",
                table: "Colors",
                column: "SubTypeHairId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Id",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HairRequests_CategoryId",
                table: "HairRequests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HairRequests_Id",
                table: "HairRequests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubTypeHairs_Id",
                table: "SubTypeHairs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubTypeHairs_TypeHairId",
                table: "SubTypeHairs",
                column: "TypeHairId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeHairs_CategoryId",
                table: "TypeHairs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeHairs_Id",
                table: "TypeHairs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorRequests");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "HairRequests");

            migrationBuilder.DropTable(
                name: "SubTypeHairs");

            migrationBuilder.DropTable(
                name: "TypeHairs");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
