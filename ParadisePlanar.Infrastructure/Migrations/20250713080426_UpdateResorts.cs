using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParadisePlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateResorts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Occupancy",
                table: "Resorts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2025, 7, 13, 13, 4, 25, 557, DateTimeKind.Local).AddTicks(9611), "9" });

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2025, 7, 13, 13, 4, 25, 557, DateTimeKind.Local).AddTicks(9626), "5" });

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2025, 7, 13, 13, 4, 25, 557, DateTimeKind.Local).AddTicks(9628), "5" });

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2025, 7, 13, 13, 4, 25, 557, DateTimeKind.Local).AddTicks(9631), "8" });

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Occupancy" },
                values: new object[] { new DateTime(2025, 7, 13, 13, 4, 25, 557, DateTimeKind.Local).AddTicks(9633), "9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Occupancy",
                table: "Resorts");

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 13, 12, 28, 11, 605, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 13, 12, 28, 11, 605, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 13, 12, 28, 11, 605, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 13, 12, 28, 11, 605, DateTimeKind.Local).AddTicks(7188));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 13, 12, 28, 11, 605, DateTimeKind.Local).AddTicks(7190));
        }
    }
}
