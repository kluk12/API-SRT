using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRT.Migrations
{
    /// <inheritdoc />
    public partial class Reservationupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberPeopleNo",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "WhenCloseTraining",
                table: "Reservations",
                newName: "WhenCloseRezerwation");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Reservations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "GeneratorId",
                table: "Reservations",
                newName: "IsDelete");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Reservations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "WhenCloseRezerwation",
                table: "Reservations",
                newName: "WhenCloseTraining");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservations",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Reservations",
                newName: "GeneratorId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Reservations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberPeopleNo",
                table: "Reservations",
                type: "int",
                nullable: true);
        }
    }
}
