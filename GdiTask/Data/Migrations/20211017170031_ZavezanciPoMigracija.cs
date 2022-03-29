using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GdiTask.Data.Migrations
{
    public partial class ZavezanciPoMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZavezanciPO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ObsegIdentifikacije = table.Column<bool>(nullable: true),
                    OmejenObsegIdentifikacije = table.Column<bool>(nullable: false),
                    DavcnaStevilka = table.Column<long>(nullable: false),
                    MaticnaStevilka = table.Column<long>(nullable: true),
                    DatumPO = table.Column<DateTime>(nullable: true),
                    Skd = table.Column<string>(nullable: false),
                    ImePodjetja = table.Column<string>(nullable: false),
                    NaslovPodjetja = table.Column<string>(nullable: false),
                    ObcinskaEnota = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZavezanciPO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZavezanciPO");
        }
    }
}
