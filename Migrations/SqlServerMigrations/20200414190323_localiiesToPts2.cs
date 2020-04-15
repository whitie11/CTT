using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class localiiesToPts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Localities_LocalityId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_LocalityId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LocalityId",
                table: "Patients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalityId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_LocalityId",
                table: "Patients",
                column: "LocalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Localities_LocalityId",
                table: "Patients",
                column: "LocalityId",
                principalTable: "Localities",
                principalColumn: "LocalityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
