﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LambdaForums.Data.Migrations
{
    public partial class fixingnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_UsersId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_UsersId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Post");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_UserId",
                table: "Post",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_UserId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_UserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Post");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_UsersId",
                table: "Post",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_UsersId",
                table: "Post",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
