using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefReservationsMs.Migrations
{
    /// <inheritdoc />
    public partial class ModifyChefEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Surveys_ClientSurveyId",
                table: "Quotations");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.RenameColumn(
                name: "ClientSurveyId",
                table: "Quotations",
                newName: "RequestForQuotationId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_ClientSurveyId",
                table: "Quotations",
                newName: "IX_Quotations_RequestForQuotationId");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalComments",
                table: "Quotations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChefId",
                table: "Quotations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    OverallScore = table.Column<double>(type: "double precision", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuisinesCatalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    CuisineName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisinesCatalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestForQuotations",
                columns: table => new
                {
                    CorrelationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentState = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MealType = table.Column<string>(type: "text", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "integer", nullable: false),
                    CuisinePreference = table.Column<string>(type: "text", nullable: false),
                    OtherCuisinePreference = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: false),
                    ReservationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StoveType = table.Column<string>(type: "text", nullable: false),
                    NumberOfBurners = table.Column<int>(type: "integer", nullable: false),
                    HasWorkingOven = table.Column<bool>(type: "boolean", nullable: false),
                    ChefPreference = table.Column<string>(type: "text", nullable: true),
                    DietaryRestrictions = table.Column<string>(type: "text", nullable: true),
                    AdditionalComments = table.Column<string>(type: "text", nullable: true),
                    ContactEmail = table.Column<string>(type: "text", nullable: false),
                    ContactPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestForQuotations", x => x.CorrelationId);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MealTypes = table.Column<byte[]>(type: "smallint[]", nullable: false),
                    CuisineTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_CuisinesCatalog_CuisineTypeId",
                        column: x => x.CuisineTypeId,
                        principalTable: "CuisinesCatalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChefFood",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChefId = table.Column<Guid>(type: "uuid", nullable: false),
                    FoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CuisineTypeId",
                table: "Foods",
                column: "CuisineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestForQuotations_CorrelationId",
                table: "RequestForQuotations",
                column: "CorrelationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_RequestForQuotations_RequestForQuotationId",
                table: "Quotations",
                column: "RequestForQuotationId",
                principalTable: "RequestForQuotations",
                principalColumn: "CorrelationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_RequestForQuotations_RequestForQuotationId",
                table: "Quotations");

            migrationBuilder.DropTable(
                name: "ChefFood");

            migrationBuilder.DropTable(
                name: "RequestForQuotations");

            migrationBuilder.DropTable(
                name: "Chefs");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "CuisinesCatalog");

            migrationBuilder.DropColumn(
                name: "AdditionalComments",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Quotations");

            migrationBuilder.RenameColumn(
                name: "RequestForQuotationId",
                table: "Quotations",
                newName: "ClientSurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_RequestForQuotationId",
                table: "Quotations",
                newName: "IX_Quotations_ClientSurveyId");

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionalComments = table.Column<string>(type: "text", nullable: true),
                    ChefPreference = table.Column<string>(type: "text", nullable: true),
                    ContactEmail = table.Column<string>(type: "text", nullable: false),
                    ContactPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CuisinePreference = table.Column<string>(type: "text", nullable: false),
                    DietaryRestrictions = table.Column<string>(type: "text", nullable: true),
                    HasWorkingOven = table.Column<bool>(type: "boolean", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    MealType = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NumberOfBurners = table.Column<int>(type: "integer", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "integer", nullable: false),
                    ReservationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StoveType = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Surveys_ClientSurveyId",
                table: "Quotations",
                column: "ClientSurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
