using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParadisePlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewResortNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResortNos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resort_No = table.Column<int>(type: "int", nullable: false),
                    ResortId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResortNos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResortNos_Resorts_ResortId",
                        column: x => x.ResortId,
                        principalTable: "Resorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ResortNos",
                columns: new[] { "Id", "ResortId", "Resort_No", "SpecialDetail" },
                values: new object[,]
                {
                    { 1, 1, 101, null },
                    { 2, 1, 102, null },
                    { 3, 1, 103, null },
                    { 4, 1, 104, null },
                    { 5, 2, 201, null },
                    { 6, 2, 202, null },
                    { 7, 2, 203, null }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ResortNos_ResortId",
                table: "ResortNos",
                column: "ResortId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResortNos");

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 13, 13, 4, 25, 557, DateTimeKind.Local).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 13, 13, 4, 25, 557, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 13, 13, 4, 25, 557, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 13, 13, 4, 25, 557, DateTimeKind.Local).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 13, 13, 4, 25, 557, DateTimeKind.Local).AddTicks(9633));
        }
    }
}
