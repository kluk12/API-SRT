using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRT.Migrations
{
    /// <inheritdoc />
    public partial class initmodels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "TemperatureC",
                table: "Configs");

            migrationBuilder.AlterColumn<int>(
                name: "Summary",
                table: "Configs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeforStartTimeInHour",
                table: "Configs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Configs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Configs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FixedCosts",
                table: "Configs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Configs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WhenCloseTraining",
                table: "Configs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocationDictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationIframe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationLinq = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remove = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BeforStartTimeInHour = table.Column<int>(type: "int", nullable: true),
                    Summary = table.Column<int>(type: "int", nullable: true),
                    NumberPeopleNo = table.Column<int>(type: "int", nullable: true),
                    WhenCloseTraining = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    GeneratorId = table.Column<bool>(type: "bit", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: true),
                    TrainingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BeforStartTimeInHour = table.Column<int>(type: "int", nullable: true),
                    Summary = table.Column<int>(type: "int", nullable: true),
                    NumberPeople = table.Column<int>(type: "int", nullable: true),
                    FixedCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WhenCloseTraining = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneratorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModuficationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationTraining",
                columns: table => new
                {
                    ReservationsId = table.Column<int>(type: "int", nullable: false),
                    TrainingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTraining", x => new { x.ReservationsId, x.TrainingsId });
                    table.ForeignKey(
                        name: "FK_ReservationTraining_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationTraining_Training_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTraining_TrainingsId",
                table: "ReservationTraining",
                column: "TrainingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationDictionary");

            migrationBuilder.DropTable(
                name: "ReservationTraining");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropColumn(
                name: "BeforStartTimeInHour",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "FixedCosts",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "WhenCloseTraining",
                table: "Configs");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Configs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Configs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TemperatureC",
                table: "Configs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
