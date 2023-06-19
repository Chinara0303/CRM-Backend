using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateSocialsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Staff_StaffId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Socials_StaffId",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Socials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Socials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Socials_StaffId",
                table: "Socials",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Staff_StaffId",
                table: "Socials",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
