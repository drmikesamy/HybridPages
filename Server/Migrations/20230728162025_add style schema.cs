using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HybridPages.Server.Migrations
{
    /// <inheritdoc />
    public partial class addstyleschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StyleId",
                table: "Posts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StyleId",
                table: "Pages",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fonts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FontFace = table.Column<string>(type: "text", nullable: false),
                    FontPath = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fonts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeadingFontFaceId = table.Column<long>(type: "bigint", nullable: false),
                    ParagraphFontFaceId = table.Column<long>(type: "bigint", nullable: false),
                    HeadingFontColour = table.Column<string>(type: "text", nullable: false),
                    ParagraphFontColour = table.Column<string>(type: "text", nullable: false),
                    BackgroundType = table.Column<int>(type: "integer", nullable: false),
                    BackgroundColour = table.Column<string>(type: "text", nullable: false),
                    BackgroundImageUrl = table.Column<string>(type: "text", nullable: false),
                    BackgroundMeshId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Styles_BackgroundMeshes_BackgroundMeshId",
                        column: x => x.BackgroundMeshId,
                        principalTable: "BackgroundMeshes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Styles_Fonts_HeadingFontFaceId",
                        column: x => x.HeadingFontFaceId,
                        principalTable: "Fonts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Styles_Fonts_ParagraphFontFaceId",
                        column: x => x.ParagraphFontFaceId,
                        principalTable: "Fonts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fonts",
                columns: new[] { "Id", "CreatedDate", "FontFace", "FontPath", "ModifiedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Open Sans", "/css/fonts/open-sans/OpenSans-Regular.ttf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arsenal", "/css/fonts/arsenal/Arsenal-Regular.ttf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StyleId",
                table: "Posts",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_StyleId",
                table: "Pages",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_BackgroundMeshId",
                table: "Styles",
                column: "BackgroundMeshId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_HeadingFontFaceId",
                table: "Styles",
                column: "HeadingFontFaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_ParagraphFontFaceId",
                table: "Styles",
                column: "ParagraphFontFaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Styles_StyleId",
                table: "Pages",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Styles_StyleId",
                table: "Posts",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Styles_StyleId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Styles_StyleId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Fonts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_StyleId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Pages_StyleId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Pages");
        }
    }
}
