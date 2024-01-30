using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3807), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3825), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3829), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3830), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3832), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3834), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3834) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3837), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3838), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3837) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3839), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3839), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3839) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3842), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3844), new DateTime(2023, 12, 24, 20, 19, 8, 594, DateTimeKind.Utc).AddTicks(3843) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
