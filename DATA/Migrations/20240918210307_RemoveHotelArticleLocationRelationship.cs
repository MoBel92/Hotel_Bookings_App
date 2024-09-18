using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHotelArticleLocationRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelArticles_Locations_LocationId",
                table: "HotelArticles");

            migrationBuilder.DropIndex(
                name: "IX_HotelArticles_LocationId",
                table: "HotelArticles");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "HotelArticles");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "HotelArticles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfGuests",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequests",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "HotelArticles");

            migrationBuilder.DropColumn(
                name: "NumberOfGuests",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "SpecialRequests",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "HotelArticles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelArticles_LocationId",
                table: "HotelArticles",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelArticles_Locations_LocationId",
                table: "HotelArticles",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "IdLocation",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
