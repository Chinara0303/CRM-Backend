using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffPositions");

            migrationBuilder.DropTable(
                name: "StaffSocials");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffPositions_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffSocials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffSocials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffSocials_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_StaffPositions_PositionId",
                table: "StaffPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPositions_StaffId",
                table: "StaffPositions",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSocials_StaffId",
                table: "StaffSocials",
                column: "StaffId");
        }
    }
}
