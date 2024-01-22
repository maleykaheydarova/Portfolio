using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class miginitt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_Portfolio_CategoryID_Deleted",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_WorkCategoryID",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Portfolios");

            migrationBuilder.AddColumn<string>(
                name: "WorkImgPath",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "idx_Portfolio_CategoryID_Deleted",
                table: "Portfolios",
                columns: new[] { "WorkCategoryID", "Deleted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_Portfolio_CategoryID_Deleted",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "WorkImgPath",
                table: "Portfolios");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "idx_Portfolio_CategoryID_Deleted",
                table: "Portfolios",
                columns: new[] { "CategoryID", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_WorkCategoryID",
                table: "Portfolios",
                column: "WorkCategoryID");
        }
    }
}
