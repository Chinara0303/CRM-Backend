using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(4978), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(4987), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(4985) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(4994), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(4997), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(4996) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(4999), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5000), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5002), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5003), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5003) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5005), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5006), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5006) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5007), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5009), new DateTime(2023, 7, 4, 10, 56, 13, 811, DateTimeKind.Utc).AddTicks(5008) });
        }
    }
}
