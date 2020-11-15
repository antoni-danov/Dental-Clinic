using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalClinic_1._1.Data.Migrations
{
    public partial class AddtableTown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TownId",
                table: "Users",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Town_TownId",
                table: "Users",
                column: "TownId",
                principalTable: "Town",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Town_TownId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropIndex(
                name: "IX_Users_TownId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "Users");
        }
    }
}
