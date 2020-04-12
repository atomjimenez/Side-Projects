using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acongrebility.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalName = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    ProposedBy = table.Column<string>(nullable: true),
                    PassedHouse = table.Column<bool>(nullable: false),
                    PassedSenate = table.Column<bool>(nullable: false),
                    DateProposed = table.Column<DateTime>(nullable: false),
                    DatePassedFailed = table.Column<DateTime>(nullable: false),
                    RepSupport = table.Column<int>(nullable: false),
                    DemSupport = table.Column<int>(nullable: false),
                    IndSupport = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Congressmembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateTookOffice = table.Column<DateTime>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    Party = table.Column<string>(nullable: true),
                    VotingHistory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Congressmembers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Congressmembers");
        }
    }
}
