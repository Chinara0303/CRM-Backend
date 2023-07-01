using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateEnumTablesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weekday",
                table: "Weeks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1294), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1303), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1302) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1307), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1308), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1307) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1309), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1311), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1312), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1313), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1312) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1314), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1315), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1314) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1316), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1317), new DateTime(2023, 6, 29, 9, 49, 48, 52, DateTimeKind.Utc).AddTicks(1316) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weekday",
                table: "Weeks");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6482), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6490), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6489) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6495), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6496), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6495) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6497), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6498), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6498) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6499), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6500), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6501), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6502), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6503), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6504), new DateTime(2023, 6, 29, 9, 31, 50, 890, DateTimeKind.Utc).AddTicks(6503) });
        }
    }
}
