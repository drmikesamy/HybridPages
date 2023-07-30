using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HybridPages.Server.Migrations
{
    /// <inheritdoc />
    public partial class removelinkedlistcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PreviousPostId",
                table: "Posts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NextPostId",
                table: "Posts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PreviousPostId",
                table: "Posts",
                type: "bigint",
                nullable: true);
        }
    }
}
