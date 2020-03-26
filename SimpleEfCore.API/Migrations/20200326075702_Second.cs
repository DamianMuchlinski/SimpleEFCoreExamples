using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleEfCore.API.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workbook",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workbook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Periodicity = table.Column<byte>(nullable: false),
                    ReleaseDateTime = table.Column<DateTime>(nullable: true),
                    WorkbookId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Workbook_WorkbookId",
                        column: x => x.WorkbookId,
                        principalTable: "Workbook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkbookSeries",
                columns: table => new
                {
                    workbookId = table.Column<Guid>(nullable: false),
                    seriesId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkbookSeries", x => new { x.workbookId, x.seriesId });
                    table.ForeignKey(
                        name: "FK_WorkbookSeries_Series_seriesId",
                        column: x => x.seriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkbookSeries_Workbook_workbookId",
                        column: x => x.workbookId,
                        principalTable: "Workbook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_WorkbookId",
                table: "Series",
                column: "WorkbookId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkbookSeries_seriesId",
                table: "WorkbookSeries",
                column: "seriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkbookSeries");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Workbook");
        }
    }
}
