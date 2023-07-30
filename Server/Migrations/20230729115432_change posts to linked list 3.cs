using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HybridPages.Server.Migrations
{
    /// <inheritdoc />
    public partial class changepoststolinkedlist3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "NextPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PreviousPostId",
                table: "Posts");
        }
    }
}
