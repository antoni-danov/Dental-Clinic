using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalClinic_1._1.Migrations
{
    public partial class AddcolumntoApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserSpecialization");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AllDentistsViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Autobiography",
                table: "AllDentistsViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpecialtyId",
                table: "Users",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Specializations_SpecialtyId",
                table: "Users",
                column: "SpecialtyId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Specializations_SpecialtyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SpecialtyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AllDentistsViewModel");

            migrationBuilder.DropColumn(
                name: "Autobiography",
                table: "AllDentistsViewModel");

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
                name: "IX_ApplicationUserSpecialization_UsersId",
                table: "ApplicationUserSpecialization",
                column: "UsersId");
        }
    }
}
