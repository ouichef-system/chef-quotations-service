using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefReservationsMs.Migrations
{
    /// <inheritdoc />
    public partial class ModifyFoodEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_CuisinesCatalog_CuisineTypeId",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "ChefFood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuisinesCatalog",
                table: "CuisinesCatalog");

            migrationBuilder.RenameTable(
                name: "CuisinesCatalog",
                newName: "CuisineCatalogs");

            migrationBuilder.AddColumn<Guid>(
                name: "ChefId",
                table: "Foods",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Foods",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuisineCatalogs",
                table: "CuisineCatalogs",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Chefs",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsActive", "Name", "OverallScore", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"), new DateTime(2024, 2, 25, 3, 44, 18, 190, DateTimeKind.Utc).AddTicks(5460), "jbasalo", "Chef italiano", true, "Claudio Paolini", 5.0, null, null });

            migrationBuilder.InsertData(
                table: "CuisineCatalogs",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CuisineName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("4827d138-5ff1-4714-95a1-414d950aa817"), new DateTime(2024, 2, 25, 3, 44, 18, 190, DateTimeKind.Utc).AddTicks(8497), "jbasalo", "Pasta", null, null });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "ChefId", "CreatedAt", "CreatedBy", "CuisineTypeId", "MealTypes", "Name", "Score", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("13743cf1-650b-4522-91fc-7b7210a71419"), new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"), new DateTime(2024, 2, 25, 3, 44, 18, 191, DateTimeKind.Utc).AddTicks(1951), "jbasalo", new Guid("4827d138-5ff1-4714-95a1-414d950aa817"), new byte[] { 3, 2 }, "Fettucini a la parmessiana", 2.0, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_ChefId",
                table: "Foods",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Chefs_ChefId",
                table: "Foods",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_CuisineCatalogs_CuisineTypeId",
                table: "Foods",
                column: "CuisineTypeId",
                principalTable: "CuisineCatalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Chefs_ChefId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_CuisineCatalogs_CuisineTypeId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_ChefId",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuisineCatalogs",
                table: "CuisineCatalogs");

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("13743cf1-650b-4522-91fc-7b7210a71419"));

            migrationBuilder.DeleteData(
                table: "Chefs",
                keyColumn: "Id",
                keyValue: new Guid("41d83dd8-0fa8-46ab-8b51-2679009a20db"));

            migrationBuilder.DeleteData(
                table: "CuisineCatalogs",
                keyColumn: "Id",
                keyValue: new Guid("4827d138-5ff1-4714-95a1-414d950aa817"));

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Foods");

            migrationBuilder.RenameTable(
                name: "CuisineCatalogs",
                newName: "CuisinesCatalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuisinesCatalog",
                table: "CuisinesCatalog",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChefFood",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChefId = table.Column<Guid>(type: "uuid", nullable: false),
                    FoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChefFood_Chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChefFood_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChefFood_ChefId",
                table: "ChefFood",
                column: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_ChefFood_FoodId",
                table: "ChefFood",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_CuisinesCatalog_CuisineTypeId",
                table: "Foods",
                column: "CuisineTypeId",
                principalTable: "CuisinesCatalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
