using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateTableAppuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3467), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3472), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3471) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3475), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3476), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3475) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3477), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3477), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3478), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3479), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3478) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3479), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3480), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3481), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3482), new DateTime(2023, 7, 4, 10, 33, 15, 253, DateTimeKind.Utc).AddTicks(3481) });
        }
    }
}
