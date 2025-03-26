using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T4.PR1.Migrations
{
    /// <inheritdoc />
    public partial class AddDecimalPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Simulations",
                keyColumn: "Id",
                keyValue: 1,
                column: "SimulationDate",
                value: new DateTime(2025, 3, 26, 17, 26, 12, 87, DateTimeKind.Local).AddTicks(6802));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Simulations",
                keyColumn: "Id",
                keyValue: 1,
                column: "SimulationDate",
                value: new DateTime(2025, 3, 26, 17, 20, 50, 300, DateTimeKind.Local).AddTicks(9843));
        }
    }
}
