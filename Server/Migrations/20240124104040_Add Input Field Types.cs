using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HybridPages.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddInputFieldTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtmlContent",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "InputFieldAttributeTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttributeName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputFieldAttributeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputFieldTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tag = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputFieldTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputFieldAttributeTypeInputFieldType",
                columns: table => new
                {
                    InputFieldAttributeTypeId = table.Column<long>(type: "bigint", nullable: false),
                    InputFieldTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputFieldAttributeTypeInputFieldType", x => new { x.InputFieldAttributeTypeId, x.InputFieldTypeId });
                    table.ForeignKey(
                        name: "FK_InputFieldAttributeTypeInputFieldType_InputFieldAttributeTy~",
                        column: x => x.InputFieldAttributeTypeId,
                        principalTable: "InputFieldAttributeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputFieldAttributeTypeInputFieldType_InputFieldTypes_Input~",
                        column: x => x.InputFieldTypeId,
                        principalTable: "InputFieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputFields",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InputFieldTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputFields_InputFieldTypes_InputFieldTypeId",
                        column: x => x.InputFieldTypeId,
                        principalTable: "InputFieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputFieldAttribute",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InputFieldAttributeTypeId = table.Column<long>(type: "bigint", nullable: false),
                    InputFieldId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputFieldAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputFieldAttribute_InputFieldAttributeTypes_InputFieldAttr~",
                        column: x => x.InputFieldAttributeTypeId,
                        principalTable: "InputFieldAttributeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputFieldAttribute_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "InputFieldAttributeTypes",
                columns: new[] { "Id", "AttributeName", "CreatedDate", "ModifiedDate" },
                values: new object[,]
                {
                    { 1L, "accept", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "capture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "multiple", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "alt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, "formaction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, "formenctype", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, "formmethod", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, "formnovalidate", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, "formtarget", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, "height", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, "src", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, "width", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, "checked", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, "required", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, "popovertarget", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, "popovertargetaction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, "dirname", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, "autocapitalize", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, "autocomplete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, "list", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, "maxlength", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, "minlength", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, "pattern", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, "placeholder", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, "readonly", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26L, "size", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27L, "minlength", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28L, "min", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29L, "step", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "InputFieldTypes",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Tag" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "file" },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "image" },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "checkbox" },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "radio" },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "submit" },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "button" },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hidden" },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "text" },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "search" },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "url" },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tel" },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email" },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password" },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "number" },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "range" },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "date" },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "month" },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "week" },
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "time" },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "datetime-local" },
                    { 21L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "color" }
                });

            migrationBuilder.InsertData(
                table: "InputFieldAttributeTypeInputFieldType",
                columns: new[] { "InputFieldAttributeTypeId", "InputFieldTypeId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 3L, 1L },
                    { 4L, 2L },
                    { 5L, 2L },
                    { 5L, 5L },
                    { 6L, 2L },
                    { 6L, 5L },
                    { 7L, 2L },
                    { 7L, 5L },
                    { 8L, 2L },
                    { 8L, 5L },
                    { 9L, 2L },
                    { 9L, 5L },
                    { 10L, 2L },
                    { 11L, 2L },
                    { 12L, 2L },
                    { 13L, 3L },
                    { 13L, 4L },
                    { 14L, 3L },
                    { 14L, 4L },
                    { 14L, 8L },
                    { 14L, 10L },
                    { 14L, 11L },
                    { 14L, 12L },
                    { 14L, 13L },
                    { 14L, 14L },
                    { 14L, 15L },
                    { 14L, 16L },
                    { 14L, 17L },
                    { 14L, 18L },
                    { 14L, 19L },
                    { 14L, 20L },
                    { 15L, 6L },
                    { 16L, 6L },
                    { 17L, 7L },
                    { 17L, 8L },
                    { 17L, 9L },
                    { 17L, 10L },
                    { 17L, 11L },
                    { 17L, 12L },
                    { 18L, 8L },
                    { 18L, 9L },
                    { 19L, 8L },
                    { 19L, 9L },
                    { 19L, 10L },
                    { 19L, 11L },
                    { 19L, 12L },
                    { 19L, 13L },
                    { 19L, 14L },
                    { 19L, 15L },
                    { 19L, 16L },
                    { 19L, 17L },
                    { 19L, 18L },
                    { 19L, 19L },
                    { 19L, 20L },
                    { 20L, 8L },
                    { 20L, 9L },
                    { 20L, 10L },
                    { 20L, 11L },
                    { 20L, 12L },
                    { 20L, 14L },
                    { 20L, 15L },
                    { 20L, 16L },
                    { 20L, 17L },
                    { 20L, 18L },
                    { 20L, 19L },
                    { 20L, 20L },
                    { 20L, 21L },
                    { 21L, 8L },
                    { 21L, 9L },
                    { 21L, 10L },
                    { 21L, 11L },
                    { 21L, 12L },
                    { 21L, 13L },
                    { 22L, 8L },
                    { 22L, 10L },
                    { 22L, 11L },
                    { 22L, 12L },
                    { 22L, 13L },
                    { 23L, 8L },
                    { 23L, 10L },
                    { 23L, 11L },
                    { 23L, 12L },
                    { 23L, 13L },
                    { 24L, 8L },
                    { 24L, 10L },
                    { 24L, 11L },
                    { 24L, 12L },
                    { 24L, 13L },
                    { 24L, 14L },
                    { 25L, 8L },
                    { 25L, 10L },
                    { 25L, 11L },
                    { 25L, 12L },
                    { 25L, 13L },
                    { 25L, 14L },
                    { 25L, 15L },
                    { 25L, 16L },
                    { 25L, 17L },
                    { 25L, 18L },
                    { 25L, 19L },
                    { 25L, 20L },
                    { 26L, 8L },
                    { 26L, 10L },
                    { 26L, 11L },
                    { 26L, 12L },
                    { 26L, 13L },
                    { 27L, 9L },
                    { 27L, 14L },
                    { 27L, 15L },
                    { 27L, 16L },
                    { 27L, 17L },
                    { 27L, 18L },
                    { 27L, 19L },
                    { 27L, 20L },
                    { 28L, 14L },
                    { 28L, 15L },
                    { 28L, 16L },
                    { 28L, 17L },
                    { 28L, 18L },
                    { 28L, 19L },
                    { 28L, 20L },
                    { 29L, 14L },
                    { 29L, 15L },
                    { 29L, 16L },
                    { 29L, 17L },
                    { 29L, 18L },
                    { 29L, 19L },
                    { 29L, 20L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputFieldAttribute_InputFieldAttributeTypeId",
                table: "InputFieldAttribute",
                column: "InputFieldAttributeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFieldAttribute_InputFieldId",
                table: "InputFieldAttribute",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFieldAttributeTypeInputFieldType_InputFieldTypeId",
                table: "InputFieldAttributeTypeInputFieldType",
                column: "InputFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_InputFieldTypeId",
                table: "InputFields",
                column: "InputFieldTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputFieldAttribute");

            migrationBuilder.DropTable(
                name: "InputFieldAttributeTypeInputFieldType");

            migrationBuilder.DropTable(
                name: "InputFields");

            migrationBuilder.DropTable(
                name: "InputFieldAttributeTypes");

            migrationBuilder.DropTable(
                name: "InputFieldTypes");

            migrationBuilder.AddColumn<string>(
                name: "HtmlContent",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
