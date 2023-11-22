using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactRegistrationMVC.Migrations
{
    public partial class CreatingUserContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Contact",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserId",
                table: "Contact",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_UserId",
                table: "Contact",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_UserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_UserId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contact");
        }
    }
}
