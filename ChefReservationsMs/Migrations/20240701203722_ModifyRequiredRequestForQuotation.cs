using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefReservationsMs.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRequiredRequestForQuotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Items",
                table: "Quotations");

            migrationBuilder.RenameColumn(
                name: "AdditionalComments",
                table: "Quotations",
                newName: "ChefComments");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Quotations",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChefComments",
                table: "Quotations",
                newName: "AdditionalComments");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Quotations",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string[]>(
                name: "Items",
                table: "Quotations",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

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
                column: "CreatedAt",
                value: new DateTime(2024, 2, 25, 15, 19, 44, 658, DateTimeKind.Utc).AddTicks(1727));
        }
    }
}
