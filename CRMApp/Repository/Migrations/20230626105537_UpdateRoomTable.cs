using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8533), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8546), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8545) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8549), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8550), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8550) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8552), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8553), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8552) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8554), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8555), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8555) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8556), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8557), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8557) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8558), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8559), new DateTime(2023, 6, 23, 16, 39, 27, 431, DateTimeKind.Utc).AddTicks(8559) });
        }
    }
}
