using Microsoft.EntityFrameworkCore.Migrations;

namespace GdiTask.Data.Migrations
{
    public partial class ZavezanciPoMigracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaticnaStevilka",
                table: "ZavezanciPO",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "MaticnaStevilka",
                table: "ZavezanciPO",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
