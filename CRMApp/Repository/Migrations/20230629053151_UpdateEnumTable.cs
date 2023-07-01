using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateEnumTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weekday",
                table: "Weeks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Weeks",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Weeks");

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
    }
}
