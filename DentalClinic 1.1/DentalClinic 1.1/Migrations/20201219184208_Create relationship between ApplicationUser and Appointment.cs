using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalClinic_1._1.Migrations
{
    public partial class CreaterelationshipbetweenApplicationUserandAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Specializations_SpecializationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SpecializationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "AllDentistsViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserSpecialization",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSpecialization", x => new { x.SpecializationId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserSpecialization_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSpecialization_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSpecialization_UsersId",
                table: "ApplicationUserSpecialization",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "ApplicationUserSpecialization");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "AllDentistsViewModel");

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpecializationId",
                table: "Users",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Specializations_SpecializationId",
                table: "Users",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
