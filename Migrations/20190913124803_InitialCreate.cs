using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeModels",
                columns: table => new
                {
                    HomeID = table.Column<string>(nullable: false),
                    HomeName = table.Column<string>(nullable: false),
                    HomePassword = table.Column<string>(nullable: false),
                    HomeAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeModels", x => x.HomeID);
                });

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    ProductID = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    ProductFromWhere = table.Column<string>(nullable: true),
                    ProductAmount = table.Column<int>(nullable: false),
                    ProductAmountType = table.Column<string>(nullable: false),
                    ProductPrice = table.Column<int>(nullable: false),
                    addedByUserName = table.Column<string>(nullable: true),
                    deletedByUserName = table.Column<string>(nullable: true),
                    updatedByUserName = table.Column<string>(nullable: true),
                    takenByUserName = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    isTaken = table.Column<bool>(nullable: false),
                    isUpdated = table.Column<bool>(nullable: false),
                    ProductHomeRefID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_ProductModels_HomeModels_ProductHomeRefID",
                        column: x => x.ProductHomeRefID,
                        principalTable: "HomeModels",
                        principalColumn: "HomeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    UserPassword = table.Column<string>(nullable: false),
                    UserFullName = table.Column<string>(nullable: false),
                    UserPhotoURL = table.Column<string>(nullable: true),
                    UserHomeRefID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_UserModels_HomeModels_UserHomeRefID",
                        column: x => x.UserHomeRefID,
                        principalTable: "HomeModels",
                        principalColumn: "HomeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_ProductHomeRefID",
                table: "ProductModels",
                column: "ProductHomeRefID");

            migrationBuilder.CreateIndex(
                name: "IX_UserModels_UserHomeRefID",
                table: "UserModels",
                column: "UserHomeRefID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.DropTable(
                name: "HomeModels");
        }
    }
}
