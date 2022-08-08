using FishingTrip.Domain.DetailedDomains;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Text.Json;

#nullable disable

namespace FishingTrip.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class modevv01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DefaultUserId",
                table: "Profiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<UserProfile>(
                name: "ProfileDetails",
                table: "Profiles",
                type: "jsonb",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Port",
                columns: table => new
                {
                    PortId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CityName = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.PortId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Profile = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    OperatingPortPortId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boats_Port_OperatingPortPortId",
                        column: x => x.OperatingPortPortId,
                        principalTable: "Port",
                        principalColumn: "PortId");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Users_BookedByUserId",
                        column: x => x.BookedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TripMember",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(type: "character varying(15)", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripMember", x => new { x.PhoneNumber, x.Role });
                    table.ForeignKey(
                        name: "FK_TripMember_Profiles_PhoneNumber",
                        column: x => x.PhoneNumber,
                        principalTable: "Profiles",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripMember_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_DefaultUserId",
                table: "Profiles",
                column: "DefaultUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boats_OperatingPortPortId",
                table: "Boats",
                column: "OperatingPortPortId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BookedByUserId",
                table: "Booking",
                column: "BookedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TripMember_UserId",
                table: "TripMember",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_DefaultUserId",
                table: "Profiles",
                column: "DefaultUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_DefaultUserId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "TripMember");

            migrationBuilder.DropTable(
                name: "Port");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_DefaultUserId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "DefaultUserId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileDetails",
                table: "Profiles");
        }
    }
}
