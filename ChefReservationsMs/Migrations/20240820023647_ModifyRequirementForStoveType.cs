using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefReservationsMs.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRequirementForStoveType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StoveType",
                table: "RequestForQuotations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Chefs",
                keyColumn: "Id",
                keyValue: new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"),
                column: "CreatedAt",
                value: new DateTime(2024, 8, 20, 2, 36, 45, 530, DateTimeKind.Utc).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "CuisineCatalogs",
                keyColumn: "Id",
                keyValue: new Guid("4827d138-5ff1-4714-95a1-414d950aa817"),
                column: "CreatedAt",
                value: new DateTime(2024, 8, 20, 2, 36, 45, 530, DateTimeKind.Utc).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("13743cf1-650b-4522-91fc-7b7210a71419"),
                column: "CreatedAt",
                value: new DateTime(2024, 8, 20, 2, 36, 45, 531, DateTimeKind.Utc).AddTicks(149));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StoveType",
                table: "RequestForQuotations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Chefs",
                keyColumn: "Id",
                keyValue: new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"),
                column: "CreatedAt",
                value: new DateTime(2024, 7, 10, 1, 41, 47, 836, DateTimeKind.Utc).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "CuisineCatalogs",
                keyColumn: "Id",
                keyValue: new Guid("4827d138-5ff1-4714-95a1-414d950aa817"),
                column: "CreatedAt",
                value: new DateTime(2024, 7, 10, 1, 41, 47, 836, DateTimeKind.Utc).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("13743cf1-650b-4522-91fc-7b7210a71419"),
                column: "CreatedAt",
                value: new DateTime(2024, 7, 10, 1, 41, 47, 837, DateTimeKind.Utc).AddTicks(1959));
        }
    }
}
