using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateGroupsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Seanses_SeansId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "SeansId",
                table: "Groups",
                newName: "TimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_SeansId",
                table: "Groups",
                newName: "IX_Groups_TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Times_TimeId",
                table: "Groups",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Times_TimeId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "TimeId",
                table: "Groups",
                newName: "SeansId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_TimeId",
                table: "Groups",
                newName: "IX_Groups_SeansId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Seanses_SeansId",
                table: "Groups",
                column: "SeansId",
                principalTable: "Seanses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
