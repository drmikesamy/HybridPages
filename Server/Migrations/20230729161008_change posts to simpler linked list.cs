using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HybridPages.Server.Migrations
{
    /// <inheritdoc />
    public partial class changepoststosimplerlinkedlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_NextPostId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_PreviousPostId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_NextPostId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PreviousPostId",
                table: "Posts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Posts_NextPostId",
                table: "Posts",
                column: "NextPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PreviousPostId",
                table: "Posts",
                column: "PreviousPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_NextPostId",
                table: "Posts",
                column: "NextPostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_PreviousPostId",
                table: "Posts",
                column: "PreviousPostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
