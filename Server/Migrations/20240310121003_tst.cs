using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HybridPages.Server.Migrations
{
    /// <inheritdoc />
    public partial class tst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputFieldAttribute_InputFieldAttributeTypes_InputFieldAttr~",
                table: "InputFieldAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_InputFields_InputFieldTypes_InputFieldTypeId",
                table: "InputFields");

            migrationBuilder.DropIndex(
                name: "IX_InputFields_InputFieldTypeId",
                table: "InputFields");

            migrationBuilder.DropIndex(
                name: "IX_InputFieldAttribute_InputFieldAttributeTypeId",
                table: "InputFieldAttribute");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "InputFieldTypeId",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "InputFieldAttributeTypeId",
                table: "InputFieldAttribute");

            migrationBuilder.AddColumn<int>(
                name: "InputFieldType",
                table: "InputFields",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InputFieldAttributeType",
                table: "InputFieldAttribute",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputFieldType",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "InputFieldAttributeType",
                table: "InputFieldAttribute");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "InputFieldTypeId",
                table: "InputFields",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "InputFieldAttributeTypeId",
                table: "InputFieldAttribute",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_InputFieldTypeId",
                table: "InputFields",
                column: "InputFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFieldAttribute_InputFieldAttributeTypeId",
                table: "InputFieldAttribute",
                column: "InputFieldAttributeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputFieldAttribute_InputFieldAttributeTypes_InputFieldAttr~",
                table: "InputFieldAttribute",
                column: "InputFieldAttributeTypeId",
                principalTable: "InputFieldAttributeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputFields_InputFieldTypes_InputFieldTypeId",
                table: "InputFields",
                column: "InputFieldTypeId",
                principalTable: "InputFieldTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
