using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalClinic_1._1.Data.Migrations
{
    public partial class addcolumnstoAllPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AllPatientsViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AllPatientsViewModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AllPatientsViewModel");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AllPatientsViewModel");
        }
    }
}
