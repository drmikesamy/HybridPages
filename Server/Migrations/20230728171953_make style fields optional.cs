using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HybridPages.Server.Migrations
{
    /// <inheritdoc />
    public partial class makestylefieldsoptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Styles_BackgroundMeshes_BackgroundMeshId",
                table: "Styles");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_Fonts_HeadingFontFaceId",
                table: "Styles");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_Fonts_ParagraphFontFaceId",
                table: "Styles");

            migrationBuilder.DeleteData(
                table: "ColourPoints",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ColourPoints",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ColourPoints",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ColourPoints",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ColourPoints",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ColourPoints",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ColourPoints",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ColourPoints",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "BackgroundMeshes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<long>(
                name: "ParagraphFontFaceId",
                table: "Styles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "ParagraphFontColour",
                table: "Styles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "HeadingFontFaceId",
                table: "Styles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "HeadingFontColour",
                table: "Styles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "BackgroundMeshId",
                table: "Styles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundImageUrl",
                table: "Styles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundColour",
                table: "Styles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_BackgroundMeshes_BackgroundMeshId",
                table: "Styles",
                column: "BackgroundMeshId",
                principalTable: "BackgroundMeshes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_Fonts_HeadingFontFaceId",
                table: "Styles",
                column: "HeadingFontFaceId",
                principalTable: "Fonts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_Fonts_ParagraphFontFaceId",
                table: "Styles",
                column: "ParagraphFontFaceId",
                principalTable: "Fonts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Styles_BackgroundMeshes_BackgroundMeshId",
                table: "Styles");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_Fonts_HeadingFontFaceId",
                table: "Styles");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_Fonts_ParagraphFontFaceId",
                table: "Styles");

            migrationBuilder.AlterColumn<long>(
                name: "ParagraphFontFaceId",
                table: "Styles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParagraphFontColour",
                table: "Styles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HeadingFontFaceId",
                table: "Styles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeadingFontColour",
                table: "Styles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BackgroundMeshId",
                table: "Styles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundImageUrl",
                table: "Styles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundColour",
                table: "Styles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "BackgroundMeshes",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ColourPoints",
                columns: new[] { "Id", "A", "Alpha", "BackgroundMeshId", "CreatedDate", "H", "HPosAbs", "HPosPercent", "IsBackground", "L", "LayerHeight", "ModifiedDate", "S", "VPosAbs", "VPosPercent" },
                values: new object[,]
                {
                    { 1L, 1f, 100, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 237, 0, 0, true, 50, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 0, 0 },
                    { 2L, 1f, 50, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 228, 0, 55, false, 83, 1f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 0, 68 },
                    { 3L, 0.84f, 50, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 0, 38, false, 50, 2f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 0, 31 },
                    { 4L, 1f, 50, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 310, 0, 24, false, 60, 3f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 0, 60 },
                    { 5L, 1f, 50, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 0, 67, false, 62, 4f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 0, 41 },
                    { 6L, 1f, 50, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 0, 0, false, 73, 5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 100 },
                    { 7L, 1f, 50, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 0, 80, false, 76, 6f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 0, 100 },
                    { 8L, 1f, 50, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 258, 0, 15, false, 11, 7f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 0, 20 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_BackgroundMeshes_BackgroundMeshId",
                table: "Styles",
                column: "BackgroundMeshId",
                principalTable: "BackgroundMeshes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_Fonts_HeadingFontFaceId",
                table: "Styles",
                column: "HeadingFontFaceId",
                principalTable: "Fonts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_Fonts_ParagraphFontFaceId",
                table: "Styles",
                column: "ParagraphFontFaceId",
                principalTable: "Fonts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
