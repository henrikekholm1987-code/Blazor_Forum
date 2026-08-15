using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUserToComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ThreadItems_ThreadItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ThreadItems_ApplicationUsers_AuthorId",
                table: "ThreadItems");

            migrationBuilder.DropIndex(
                name: "IX_ThreadItems_AuthorId",
                table: "ThreadItems");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ThreadItems");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "ThreadItems");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ThreadItems");

            migrationBuilder.RenameColumn(
                name: "IsPinned",
                table: "ThreadItems",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ThreadItemId",
                table: "Comments",
                newName: "ThreadItemThreadId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Comments",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ThreadItemId",
                table: "Comments",
                newName: "IX_Comments_ThreadItemThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                newName: "IX_Comments_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThreadItems_ApplicationUserId",
                table: "ThreadItems",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ThreadItems_ThreadItemThreadId",
                table: "Comments",
                column: "ThreadItemThreadId",
                principalTable: "ThreadItems",
                principalColumn: "ThreadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThreadItems_ApplicationUsers_ApplicationUserId",
                table: "ThreadItems",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ThreadItems_ThreadItemThreadId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ThreadItems_ApplicationUsers_ApplicationUserId",
                table: "ThreadItems");

            migrationBuilder.DropIndex(
                name: "IX_ThreadItems_ApplicationUserId",
                table: "ThreadItems");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ThreadItems",
                newName: "IsPinned");

            migrationBuilder.RenameColumn(
                name: "ThreadItemThreadId",
                table: "Comments",
                newName: "ThreadItemId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Comments",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ThreadItemThreadId",
                table: "Comments",
                newName: "IX_Comments_ThreadItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                newName: "IX_Comments_AuthorId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "ThreadItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "ThreadItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ThreadItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThreadItems_AuthorId",
                table: "ThreadItems",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ThreadItems_ThreadItemId",
                table: "Comments",
                column: "ThreadItemId",
                principalTable: "ThreadItems",
                principalColumn: "ThreadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThreadItems_ApplicationUsers_AuthorId",
                table: "ThreadItems",
                column: "AuthorId",
                principalTable: "ApplicationUsers",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
