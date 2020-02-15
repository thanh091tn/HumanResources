using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class add_AwAndPnTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AwAndPn",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdateBy = table.Column<Guid>(nullable: true),
                    RemovedBy = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwAndPn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AndPnEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdateBy = table.Column<Guid>(nullable: true),
                    RemovedBy = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    AwAndPnId = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndPnEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AndPnEmployee_AwAndPn_AwAndPnId",
                        column: x => x.AwAndPnId,
                        principalTable: "AwAndPn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AndPnEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AndPnEmployee_AwAndPnId",
                table: "AndPnEmployee",
                column: "AwAndPnId");

            migrationBuilder.CreateIndex(
                name: "IX_AndPnEmployee_EmployeeId",
                table: "AndPnEmployee",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AndPnEmployee");

            migrationBuilder.DropTable(
                name: "AwAndPn");
        }
    }
}
