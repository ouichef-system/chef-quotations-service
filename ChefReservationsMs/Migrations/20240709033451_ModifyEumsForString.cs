using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefReservationsMs.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEumsForString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chefs",
                keyColumn: "Id",
                keyValue: new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"),
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 3, 34, 50, 505, DateTimeKind.Utc).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "CuisineCatalogs",
                keyColumn: "Id",
                keyValue: new Guid("4827d138-5ff1-4714-95a1-414d950aa817"),
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 3, 34, 50, 505, DateTimeKind.Utc).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("13743cf1-650b-4522-91fc-7b7210a71419"),
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 3, 34, 50, 505, DateTimeKind.Utc).AddTicks(6898));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chefs",
                keyColumn: "Id",
                keyValue: new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"),
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 20, 37, 19, 27, DateTimeKind.Utc).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "CuisineCatalogs",
                keyColumn: "Id",
                keyValue: new Guid("4827d138-5ff1-4714-95a1-414d950aa817"),
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 20, 37, 19, 27, DateTimeKind.Utc).AddTicks(6861));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("13743cf1-650b-4522-91fc-7b7210a71419"),
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 20, 37, 19, 27, DateTimeKind.Utc).AddTicks(9918));
        }
    }
}
