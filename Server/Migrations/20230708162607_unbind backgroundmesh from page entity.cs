using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HybridPages.Server.Migrations
{
    /// <inheritdoc />
    public partial class unbindbackgroundmeshfrompageentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_BackgroundMeshes_BackgroundMeshId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_BackgroundMeshId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "BackgroundMeshId",
                table: "Pages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BackgroundMeshId",
                table: "Pages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_BackgroundMeshId",
                table: "Pages",
                column: "BackgroundMeshId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_BackgroundMeshes_BackgroundMeshId",
                table: "Pages",
                column: "BackgroundMeshId",
                principalTable: "BackgroundMeshes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
