using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Seanses_SeansId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "SeansId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Seanses_SeansId",
                table: "Groups",
                column: "SeansId",
                principalTable: "Seanses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Seanses_SeansId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "SeansId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Seanses_SeansId",
                table: "Groups",
                column: "SeansId",
                principalTable: "Seanses",
                principalColumn: "Id");
        }
    }
}
