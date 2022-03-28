using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkExample.EntityFramework.Migrations
{
    public partial class AddStatusField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Blogs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "Draft");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Blogs");
        }
    }
}
