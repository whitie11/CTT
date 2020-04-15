using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class localiiesToPts1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Localities_LocalityId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "LocalityId",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Localities_LocalityId",
                table: "Patients",
                column: "LocalityId",
                principalTable: "Localities",
                principalColumn: "LocalityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Localities_LocalityId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "LocalityId",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Localities_LocalityId",
                table: "Patients",
                column: "LocalityId",
                principalTable: "Localities",
                principalColumn: "LocalityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
