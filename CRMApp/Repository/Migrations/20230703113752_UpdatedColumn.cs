using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdatedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Contacts",
                newName: "EducationId");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2252), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2260), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2259) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2265), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2266), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2266) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2267), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2270), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2269) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2272), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2274), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2273) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2278), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2279), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2278) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2280), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2281), new DateTime(2023, 7, 3, 15, 37, 51, 354, DateTimeKind.Utc).AddTicks(2280) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EducationId",
                table: "Contacts",
                newName: "CourseId");

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
    }
}
