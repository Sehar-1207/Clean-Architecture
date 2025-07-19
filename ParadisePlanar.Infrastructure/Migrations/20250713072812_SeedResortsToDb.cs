using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParadisePlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedResortsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Resorts",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 13, 12, 28, 11, 605, DateTimeKind.Local).AddTicks(7160), "A tranquil retreat bathed in golden sunlight year-round, surrounded by cascading springs and whispering palms.", "/images/resort1.jpg", "Solstice Haven", 13800000.0, 23000, null },
                    { 2, new DateTime(2025, 7, 13, 12, 28, 11, 605, DateTimeKind.Local).AddTicks(7181), "An island sanctuary encircled by sapphire lagoons and blooming flora, offering the essence of tropical eternity.", "/images/resort2.jpg", "Azure Elysium", 14900000.0, 25000, null },
                    { 3, new DateTime(2025, 7, 13, 12, 28, 11, 605, DateTimeKind.Local).AddTicks(7183), "A cloud-piercing summit lodge where glass observatories open to panoramic starfields and northern lights.", "/images/resort3.jpg", "Celestara Peak", 15700000.0, 28000, null },
                    { 4, new DateTime(2025, 7, 13, 12, 28, 11, 605, DateTimeKind.Local).AddTicks(7188), "Hidden deep within a rainforest, this eco-luxury resort features glowing waterfalls and mineral-rich lagoons.", "/images/resort4.jpg", "Luminar Springs", 12400000.0, 20000, null },
                    { 5, new DateTime(2025, 7, 13, 12, 28, 11, 605, DateTimeKind.Local).AddTicks(7190), "A celestial coastal escape where white sand meets diamond-clear water, kissed by heavenly breezes.", "/images/resort5.jpg", "Seraphine Bay", 14200000.0, 24000, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
