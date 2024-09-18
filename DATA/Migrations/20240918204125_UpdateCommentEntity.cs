using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelArticles_HotelArticleHotelID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserIdUser",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_HotelArticleHotelID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserIdUser",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "HotelArticleHotelID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HotelArticleHotelID",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserIdUser",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelArticleHotelID",
                table: "Bookings",
                column: "HotelArticleHotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserIdUser",
                table: "Bookings",
                column: "UserIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelArticles_HotelArticleHotelID",
                table: "Bookings",
                column: "HotelArticleHotelID",
                principalTable: "HotelArticles",
                principalColumn: "HotelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserIdUser",
                table: "Bookings",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");
        }
    }
}
