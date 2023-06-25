using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRememberMe",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRememberMe",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 11, 45, 41, 841, DateTimeKind.Utc).AddTicks(9999), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(7), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(6) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(14), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(15), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(15) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(16), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(17), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(17) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(18), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(19), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(18) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(20), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(21), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(20) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(22), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(22), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(22) });
        }
    }
}
