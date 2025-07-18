using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThePlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitWithSQLite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlannerEventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannerEventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ResourceType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlannerEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResourceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    JobID = table.Column<int>(type: "INTEGER", nullable: false),
                    ShipName = table.Column<string>(type: "TEXT", nullable: false),
                    JobCode = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", nullable: false),
                    DeparturePort = table.Column<string>(type: "TEXT", nullable: false),
                    ArrivalPort = table.Column<string>(type: "TEXT", nullable: false),
                    EditBy = table.Column<string>(type: "TEXT", nullable: false),
                    PlannerEventTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    TravelDays = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCTS = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannerEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannerEvents_PlannerEventTypes_PlannerEventTypeId",
                        column: x => x.PlannerEventTypeId,
                        principalTable: "PlannerEventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlannerEvents_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlannerEventTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Working" },
                    { 2, "Break" },
                    { 3, "Meeting" },
                    { 4, "Training" },
                    { 5, "Travel" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "ResourceType" },
                values: new object[,]
                {
                    { 1, "Resource 1", "Person" },
                    { 2, "Resource 2", "Person" },
                    { 3, "Resource 3", "Person" },
                    { 4, "Resource 4", "Person" },
                    { 5, "Resource 5", "Person" },
                    { 6, "Resource 6", "Person" },
                    { 7, "Resource 7", "Person" },
                    { 8, "Resource 8", "Person" },
                    { 9, "Resource 9", "Person" },
                    { 10, "Resource 10", "Vehicle" },
                    { 11, "Resource 11", "Vehicle" },
                    { 12, "Resource 12", "Vehicle" }
                });

            migrationBuilder.InsertData(
                table: "PlannerEvents",
                columns: new[] { "Id", "ArrivalPort", "ClientName", "Color", "DeparturePort", "Description", "EditBy", "EndDate", "IsCTS", "JobCode", "JobID", "Name", "PlannerEventTypeId", "ResourceId", "ShipName", "StartDate", "TravelDays" },
                values: new object[,]
                {
                    { 1, "Port B", "Client 1", "#FFCC00", "Port A", "Description for Event 1", "System", new DateTime(2025, 7, 19, 2, 0, 0, 0, DateTimeKind.Local), false, "J001", 1001, "Event 1", 2, 2, "Ship 1", new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, "Port B", "Client 2", "#FFCC00", "Port A", "Description for Event 2", "System", new DateTime(2025, 7, 20, 2, 0, 0, 0, DateTimeKind.Local), true, "J002", 1002, "Event 2", 3, 3, "Ship 2", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 3, "Port B", "Client 3", "#FFCC00", "Port A", "Description for Event 3", "System", new DateTime(2025, 7, 21, 2, 0, 0, 0, DateTimeKind.Local), false, "J003", 1003, "Event 3", 4, 4, "Ship 3", new DateTime(2025, 7, 21, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 4, "Port B", "Client 4", "#FFCC00", "Port A", "Description for Event 4", "System", new DateTime(2025, 7, 22, 2, 0, 0, 0, DateTimeKind.Local), true, "J004", 1004, "Event 4", 5, 5, "Ship 4", new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 5, "Port B", "Client 5", "#FFCC00", "Port A", "Description for Event 5", "System", new DateTime(2025, 7, 23, 2, 0, 0, 0, DateTimeKind.Local), false, "J005", 1005, "Event 5", 1, 6, "Ship 5", new DateTime(2025, 7, 23, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 6, "Port B", "Client 6", "#FFCC00", "Port A", "Description for Event 6", "System", new DateTime(2025, 7, 24, 2, 0, 0, 0, DateTimeKind.Local), true, "J006", 1006, "Event 6", 2, 7, "Ship 6", new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 7, "Port B", "Client 7", "#FFCC00", "Port A", "Description for Event 7", "System", new DateTime(2025, 7, 25, 2, 0, 0, 0, DateTimeKind.Local), false, "J007", 1007, "Event 7", 3, 8, "Ship 7", new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 8, "Port B", "Client 8", "#FFCC00", "Port A", "Description for Event 8", "System", new DateTime(2025, 7, 26, 2, 0, 0, 0, DateTimeKind.Local), true, "J008", 1008, "Event 8", 4, 9, "Ship 8", new DateTime(2025, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 9, "Port B", "Client 9", "#FFCC00", "Port A", "Description for Event 9", "System", new DateTime(2025, 7, 27, 2, 0, 0, 0, DateTimeKind.Local), false, "J009", 1009, "Event 9", 5, 10, "Ship 9", new DateTime(2025, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 10, "Port B", "Client 10", "#FFCC00", "Port A", "Description for Event 10", "System", new DateTime(2025, 7, 28, 2, 0, 0, 0, DateTimeKind.Local), true, "J010", 1010, "Event 10", 1, 11, "Ship 10", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Local), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlannerEvents_PlannerEventTypeId",
                table: "PlannerEvents",
                column: "PlannerEventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannerEvents_ResourceId",
                table: "PlannerEvents",
                column: "ResourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlannerEvents");

            migrationBuilder.DropTable(
                name: "PlannerEventTypes");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
