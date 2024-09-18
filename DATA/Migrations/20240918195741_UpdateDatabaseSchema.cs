using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.CreateTable(
                name: "HotelArticles",
                columns: table => new
                {
                    HotelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelStars = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelArticles", x => x.HotelID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    IdLocation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.IdLocation);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    IdComment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.IdComment);
                    table.ForeignKey(
                        name: "FK_Comments_HotelArticles_HotelID",
                        column: x => x.HotelID,
                        principalTable: "HotelArticles",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    IdBooking = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdUser = table.Column<int>(type: "int", nullable: true),
                    HotelArticleHotelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.IdBooking);
                    table.ForeignKey(
                        name: "FK_Bookings_HotelArticles_HotelArticleHotelID",
                        column: x => x.HotelArticleHotelID,
                        principalTable: "HotelArticles",
                        principalColumn: "HotelID");
                    table.ForeignKey(
                        name: "FK_Bookings_HotelArticles_HotelID",
                        column: x => x.HotelID,
                        principalTable: "HotelArticles",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelArticleHotelID",
                table: "Bookings",
                column: "HotelArticleHotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelID",
                table: "Bookings",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserIdUser",
                table: "Bookings",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_HotelID",
                table: "Comments",
                column: "HotelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "HotelArticles");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEdition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disponibilite = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    IdPersonne = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKAdherent = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.IdPersonne);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    IdEmprunt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEmprunt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRetour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FKAdherent = table.Column<int>(type: "int", nullable: false),
                    FKLivre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.IdEmprunt);
                    table.ForeignKey(
                        name: "FK_Loans_Books_FKLivre",
                        column: x => x.FKLivre,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Persons_FKAdherent",
                        column: x => x.FKAdherent,
                        principalTable: "Persons",
                        principalColumn: "IdPersonne",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKLivre = table.Column<int>(type: "int", nullable: false),
                    FKPersonne = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Reservations_Books_FKLivre",
                        column: x => x.FKLivre,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Persons_FKPersonne",
                        column: x => x.FKPersonne,
                        principalTable: "Persons",
                        principalColumn: "IdPersonne",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_FKAdherent",
                table: "Loans",
                column: "FKAdherent");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_FKLivre",
                table: "Loans",
                column: "FKLivre");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FKLivre",
                table: "Reservations",
                column: "FKLivre");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FKPersonne",
                table: "Reservations",
                column: "FKPersonne");
        }
    }
}
