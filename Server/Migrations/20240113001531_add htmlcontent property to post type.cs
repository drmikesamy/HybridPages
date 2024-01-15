using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HybridPages.Server.Migrations
{
    /// <inheritdoc />
    public partial class addhtmlcontentpropertytoposttype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HtmlContent",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtmlContent",
                table: "Posts");
        }
    }
}
