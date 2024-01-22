using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class miginit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SkillDetails_SkillID",
                table: "SkillDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "SkillDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "idx_SkillID_Deleted",
                table: "SkillDetails",
                columns: new[] { "SkillID", "Deleted" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_SkillID_Deleted",
                table: "SkillDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "SkillDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SkillDetails_SkillID",
                table: "SkillDetails",
                column: "SkillID");
        }
    }
}
