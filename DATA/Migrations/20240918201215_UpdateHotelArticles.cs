using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHotelArticles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelLocation",
                table: "HotelArticles");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "HotelLocation",
                table: "HotelArticles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
