using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bus_Reservation.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(nullable: false),
                    AdminPassword = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "booking_details",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cost = table.Column<int>(nullable: false),
                    Userid = table.Column<int>(nullable: false),
                    tripId = table.Column<int>(nullable: false),
                    seatNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_details", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "bus_details",
                columns: table => new
                {
                    busId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    busName = table.Column<string>(nullable: false),
                    busType = table.Column<string>(nullable: false),
                    isActive = table.Column<int>(nullable: false),
                    TotalSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus_details", x => x.busId);
                });

            migrationBuilder.CreateTable(
                name: "bus_trip",
                columns: table => new
                {
                    tripId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    busId = table.Column<int>(nullable: false),
                    source = table.Column<string>(nullable: false),
                    destination = table.Column<string>(nullable: false),
                    fromDatetime = table.Column<DateTime>(nullable: false),
                    toDatetime = table.Column<DateTime>(nullable: false),
                    availableSeats = table.Column<int>(nullable: false),
                    isActive = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus_trip", x => x.tripId);
                });

            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    feedBackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    feedBackMessage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback", x => x.feedBackId);
                });

            migrationBuilder.CreateTable(
                name: "station",
                columns: table => new
                {
                    stationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stationName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_station", x => x.stationId);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<int>(nullable: false),
                    BookingId = table.Column<int>(nullable: false),
                    trasactionDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 25, nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Contact = table.Column<string>(maxLength: 10, nullable: false),
                    dob = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "wallet",
                columns: table => new
                {
                    wallletId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amountRemaining = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet", x => x.wallletId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "booking_details");

            migrationBuilder.DropTable(
                name: "bus_details");

            migrationBuilder.DropTable(
                name: "bus_trip");

            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.DropTable(
                name: "station");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "wallet");
        }
    }
}
