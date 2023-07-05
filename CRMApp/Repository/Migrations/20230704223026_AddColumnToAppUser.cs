using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddColumnToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5203), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5210), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5209) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5213), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5214), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5214) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5216), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5217), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5216) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5218), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5219), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5218) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5220), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5220), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5220) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5221), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5222), new DateTime(2023, 7, 5, 2, 30, 26, 93, DateTimeKind.Utc).AddTicks(5222) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1214), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1224), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1223) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1227), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1228), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1227) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1230), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1231), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1232), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1233), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1232) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1234), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1235), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1235) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1236), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1237), new DateTime(2023, 7, 4, 18, 22, 31, 131, DateTimeKind.Utc).AddTicks(1237) });
        }
    }
}
