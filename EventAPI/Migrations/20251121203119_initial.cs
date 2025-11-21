using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    icon = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    six = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    userName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateTime>(type: "date", nullable: false),
                    finishDate = table.Column<DateTime>(type: "date", nullable: true),
                    startTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    fineshTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    placeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    category = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    constraintAge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                    table.ForeignKey(
                        name: "FK_events_User",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_events_eventCategory",
                        column: x => x.category,
                        principalTable: "eventCategory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    eventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_User",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Comments_events",
                        column: x => x.eventId,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    idNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingDate = table.Column<DateTime>(type: "date", nullable: false),
                    email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    phoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    eventId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.idNumber, x.bookingDate });
                    table.ForeignKey(
                        name: "FK_Reservations_User",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Reservations_events",
                        column: x => x.eventId,
                        principalTable: "events",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_eventId",
                table: "Comments",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId",
                table: "Comments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_events_category",
                table: "events",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_events_userId",
                table: "events",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_eventId",
                table: "Reservations",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_userId",
                table: "Reservations",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "eventCategory");
        }
    }
}
