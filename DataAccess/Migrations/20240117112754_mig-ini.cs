using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "idx_Portfolio_CategoryID_Deleted",
                table: "Portfolios",
                newName: "idx_Portfolio_WorkCategoryID_Deleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "idx_Portfolio_WorkCategoryID_Deleted",
                table: "Portfolios",
                newName: "idx_Portfolio_CategoryID_Deleted");
        }
    }
}
