using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalClinic_1._1.Data.Migrations
{
    public partial class AddtableSpecialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpecializationId",
                table: "Users",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Specialization_SpecializationId",
                table: "Users",
                column: "SpecializationId",
                principalTable: "Specialization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Specialization_SpecializationId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropIndex(
                name: "IX_Users_SpecializationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Users");
        }
    }
}
