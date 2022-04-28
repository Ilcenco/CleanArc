using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArc.Infra.Data.Migrations
{
    public partial class AddNewsPropertyText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "News");
        }
    }
}
