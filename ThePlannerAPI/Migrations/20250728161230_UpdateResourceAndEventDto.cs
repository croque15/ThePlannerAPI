using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThePlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateResourceAndEventDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Resources",
                newName: "Sector");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Resources",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "Resources",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Resources",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "MedCert",
                table: "Resources",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Elizabeth", 50, "Taylor", new DateTime(2026, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supervisor", "cruise" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Linda", 77, "Brown", new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supervisor", "oil & gas" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "George", 90, "Lucas", new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supervisor", "cargo" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Emily", 34, "Clark", new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supervisor", "cruise" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Michael", 2, "Scott", new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supervisor", "oil & gas" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Kate", 78, "Moss", new DateTime(2027, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Technician", "cruise" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Dian", 85, "Fossey", new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Technician", "oil & gas" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Leonardo", 96, "DiCaprio", null, "Technician", "cargo" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Grace", 73, "Hopper", new DateTime(2026, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Technician", "cruise" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Ada", 58, "Lovelace", new DateTime(2026, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Technician", "cargo" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Mario", 50, "Rossi", new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trainee", "cargo" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FirstName", "Hours", "LastName", "MedCert", "ResourceType", "Sector" },
                values: new object[] { "Luca", 542, "Verdi", new DateTime(2026, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trainee", "oil & gas" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "MedCert",
                table: "Resources");

            migrationBuilder.RenameColumn(
                name: "Sector",
                table: "Resources",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 1", "Person" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 2", "Person" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 3", "Person" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 4", "Person" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 5", "Person" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 6", "Person" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 7", "Person" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 8", "Person" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 9", "Person" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 10", "Vehicle" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 11", "Vehicle" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Resource 12", "Vehicle" });
        }
    }
}
