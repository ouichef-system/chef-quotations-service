using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefReservationsMs.Migrations
{
    /// <inheritdoc />
    public partial class ModifyFoodMealType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MealTypes",
                table: "Foods",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "smallint[]");

            migrationBuilder.UpdateData(
                table: "Chefs",
                keyColumn: "Id",
                keyValue: new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 25, 15, 19, 44, 657, DateTimeKind.Utc).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "CuisineCatalogs",
                keyColumn: "Id",
                keyValue: new Guid("4827d138-5ff1-4714-95a1-414d950aa817"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 25, 15, 19, 44, 657, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("13743cf1-650b-4522-91fc-7b7210a71419"),
                columns: new[] { "CreatedAt", "MealTypes" },
                values: new object[] { new DateTime(2024, 2, 25, 15, 19, 44, 658, DateTimeKind.Utc).AddTicks(1727), "Dinner,Lunch" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "MealTypes",
                table: "Foods",
                type: "smallint[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Chefs",
                keyColumn: "Id",
                keyValue: new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 25, 3, 44, 18, 190, DateTimeKind.Utc).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "CuisineCatalogs",
                keyColumn: "Id",
                keyValue: new Guid("4827d138-5ff1-4714-95a1-414d950aa817"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 25, 3, 44, 18, 190, DateTimeKind.Utc).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("13743cf1-650b-4522-91fc-7b7210a71419"),
                columns: new[] { "CreatedAt", "MealTypes" },
                values: new object[] { new DateTime(2024, 2, 25, 3, 44, 18, 191, DateTimeKind.Utc).AddTicks(1951), new byte[] { 3, 2 } });
        }
    }
}
