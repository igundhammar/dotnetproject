using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace musicshop.Migrations
{
    public partial class MusicDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Albums",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Albums");
        }
    }
}
