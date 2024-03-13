using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildrenParentProductGroup_ProductGroups_ParentId",
                table: "ChildrenParentProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroups_ChildrenParentProductGroup_ChildrenParentProductGroupId",
                table: "ProductGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildrenParentProductGroup",
                table: "ChildrenParentProductGroup");

            migrationBuilder.RenameTable(
                name: "ChildrenParentProductGroup",
                newName: "ChildrenParentProductGroups");

            migrationBuilder.RenameIndex(
                name: "IX_ChildrenParentProductGroup_ParentId",
                table: "ChildrenParentProductGroups",
                newName: "IX_ChildrenParentProductGroups_ParentId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildrenParentProductGroups",
                table: "ChildrenParentProductGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildrenParentProductGroups_ProductGroups_ParentId",
                table: "ChildrenParentProductGroups",
                column: "ParentId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroups_ChildrenParentProductGroups_ChildrenParentProductGroupId",
                table: "ProductGroups",
                column: "ChildrenParentProductGroupId",
                principalTable: "ChildrenParentProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildrenParentProductGroups_ProductGroups_ParentId",
                table: "ChildrenParentProductGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroups_ChildrenParentProductGroups_ChildrenParentProductGroupId",
                table: "ProductGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildrenParentProductGroups",
                table: "ChildrenParentProductGroups");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "ChildrenParentProductGroups",
                newName: "ChildrenParentProductGroup");

            migrationBuilder.RenameIndex(
                name: "IX_ChildrenParentProductGroups_ParentId",
                table: "ChildrenParentProductGroup",
                newName: "IX_ChildrenParentProductGroup_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildrenParentProductGroup",
                table: "ChildrenParentProductGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildrenParentProductGroup_ProductGroups_ParentId",
                table: "ChildrenParentProductGroup",
                column: "ParentId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroups_ChildrenParentProductGroup_ChildrenParentProductGroupId",
                table: "ProductGroups",
                column: "ChildrenParentProductGroupId",
                principalTable: "ChildrenParentProductGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
