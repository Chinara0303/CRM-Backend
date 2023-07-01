using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreateEnumTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weekday = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weeks", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5081), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5088), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5088) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5094), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5095), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5094) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5097), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5097), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5097) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5098), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5099), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5099) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5100), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5101), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5101) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5102), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5103), new DateTime(2023, 6, 29, 8, 39, 26, 947, DateTimeKind.Utc).AddTicks(5103) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weeks");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1036), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1047), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1046) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1051), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1051), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1051) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1053), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1053), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1053) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1054), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1055), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1056), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1057), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1058), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1059), new DateTime(2023, 6, 26, 14, 55, 36, 478, DateTimeKind.Utc).AddTicks(1059) });
        }
    }
}
