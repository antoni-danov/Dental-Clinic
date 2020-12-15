using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalClinic_1._1.Migrations
{
    public partial class AmbulatorySheettable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmbulatorySheetsId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AmbulatorySheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DentistId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interventions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmbulatorySheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmbulatorySheet_Users_DentistId",
                        column: x => x.DentistId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AmbulatorySheet_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentViewModel",
                columns: table => new
                {
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minutes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentViewModel", x => x.FirstName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AmbulatorySheetsId",
                table: "Appointments",
                column: "AmbulatorySheetsId");

            migrationBuilder.CreateIndex(
                name: "IX_AmbulatorySheet_DentistId",
                table: "AmbulatorySheet",
                column: "DentistId");

            migrationBuilder.CreateIndex(
                name: "IX_AmbulatorySheet_PatientId",
                table: "AmbulatorySheet",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AmbulatorySheet_AmbulatorySheetsId",
                table: "Appointments",
                column: "AmbulatorySheetsId",
                principalTable: "AmbulatorySheet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AmbulatorySheet_AmbulatorySheetsId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "AmbulatorySheet");

            migrationBuilder.DropTable(
                name: "AppointmentViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AmbulatorySheetsId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AmbulatorySheetsId",
                table: "Appointments");
        }
    }
}
