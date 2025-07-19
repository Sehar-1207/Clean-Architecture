using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParadisePlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAmenity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Resorts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Resorts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResortId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Resorts_ResortId",
                        column: x => x.ResortId,
                        principalTable: "Resorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "ResortId" },
                values: new object[,]
                {
                    { 1, "Outdoor pool with temperature control", "Swimming Pool", 1 },
                    { 2, "Modern fitness center open 24/7", "Gym", 1 },
                    { 3, "Relaxing massages and sauna", "Spa", 1 },
                    { 4, "Free high-speed internet", "Wi-Fi", 2 },
                    { 5, "Complimentary buffet breakfast", "Breakfast", 2 },
                    { 6, "Indoor playground for kids", "Kids Play Area", 2 },
                    { 7, "Exclusive beach access", "Private Beach", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 18, 22, 17, 2, 818, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 18, 22, 17, 2, 818, DateTimeKind.Local).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 18, 22, 17, 2, 818, DateTimeKind.Local).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 18, 22, 17, 2, 818, DateTimeKind.Local).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 18, 22, 17, 2, 818, DateTimeKind.Local).AddTicks(6756));

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_ResortId",
                table: "Amenities",
                column: "ResortId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Resorts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Resorts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 18, 11, 54, 49, 220, DateTimeKind.Local).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 18, 11, 54, 49, 220, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 18, 11, 54, 49, 220, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 18, 11, 54, 49, 220, DateTimeKind.Local).AddTicks(6528));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 18, 11, 54, 49, 220, DateTimeKind.Local).AddTicks(6529));
        }
    }
}
