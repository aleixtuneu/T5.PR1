using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T4.PR1.Migrations
{
    /// <inheritdoc />
    public partial class FixDateTimeNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Simulations",
                keyColumn: "Id",
                keyValue: 1,
                column: "SimulationDate",
                value: new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Simulations",
                keyColumn: "Id",
                keyValue: 1,
                column: "SimulationDate",
                value: new DateTime(2025, 3, 26, 17, 30, 53, 833, DateTimeKind.Local).AddTicks(4647));
        }
    }
}
