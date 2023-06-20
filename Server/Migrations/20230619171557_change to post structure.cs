using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HybridPages.Server.Migrations
{
    /// <inheritdoc />
    public partial class changetopoststructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkPage");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Links",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Links",
                newName: "Content");

            migrationBuilder.AddColumn<long>(
                name: "PageId",
                table: "Links",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Links_PageId",
                table: "Links",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Pages_PageId",
                table: "Links",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Pages_PageId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_PageId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Links",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Links",
                newName: "Path");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Links",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Links",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LinkPage",
                columns: table => new
                {
                    LinksId = table.Column<long>(type: "bigint", nullable: false),
                    PagesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPage", x => new { x.LinksId, x.PagesId });
                    table.ForeignKey(
                        name: "FK_LinkPage_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPage_Pages_PagesId",
                        column: x => x.PagesId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkPage_PagesId",
                table: "LinkPage",
                column: "PagesId");
        }
    }
}
