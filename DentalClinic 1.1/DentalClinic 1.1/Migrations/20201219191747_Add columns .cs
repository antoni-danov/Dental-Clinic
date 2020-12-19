using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalClinic_1._1.Migrations
{
    public partial class Addcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_DentistId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "DentistId",
                table: "Appointments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DentistId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Dentist",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Dentist",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Appointments",
                newName: "DentistId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                newName: "IX_Appointments_DentistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_DentistId",
                table: "Appointments",
                column: "DentistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
