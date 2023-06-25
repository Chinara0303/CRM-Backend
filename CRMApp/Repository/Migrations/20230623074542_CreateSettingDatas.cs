using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreateSettingDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Key", "ModifiedDate", "SoftDelete", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 23, 11, 45, 41, 841, DateTimeKind.Utc).AddTicks(9999), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(7), "Phone", new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(6), false, "123-123-1234" },
                    { 2, new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(14), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(15), "EmailAdress", new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(15), false, "webfull@edu.com" },
                    { 3, new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(16), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(17), "Logo", new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(17), false, "download.jpg" },
                    { 4, new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(18), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(19), "Address", new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(18), false, "132 Jefferson Avenue, Suite 22, Redwood City, CA 94872" },
                    { 5, new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(20), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(21), "Fax", new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(20), false, "123-323-3343" },
                    { 6, new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(22), new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(22), "TollFree", new DateTime(2023, 6, 23, 11, 45, 41, 842, DateTimeKind.Utc).AddTicks(22), false, "123-425-6234" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
