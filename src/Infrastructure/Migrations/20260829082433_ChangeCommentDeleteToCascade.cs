using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCommentDeleteToCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ThreadItems_ApplicationUsers_ApplicationUserId",
                table: "ThreadItems");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThreadItems_ApplicationUsers_ApplicationUserId",
                table: "ThreadItems",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ThreadItems_ApplicationUsers_ApplicationUserId",
                table: "ThreadItems");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThreadItems_ApplicationUsers_ApplicationUserId",
                table: "ThreadItems",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
