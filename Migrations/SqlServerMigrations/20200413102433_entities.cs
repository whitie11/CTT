using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Appts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Appts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "Appts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Appts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    NHSno = table.Column<string>(nullable: true),
                    CPMSno = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    StageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.StageId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeText = table.Column<string>(nullable: true),
                    TypeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appts_PatientId",
                table: "Appts",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appts_StageId",
                table: "Appts",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Appts_TypeId",
                table: "Appts",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appts_Patients_PatientId",
                table: "Appts",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appts_Stages_StageId",
                table: "Appts",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "StageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appts_Types_TypeId",
                table: "Appts",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appts_Patients_PatientId",
                table: "Appts");

            migrationBuilder.DropForeignKey(
                name: "FK_Appts_Stages_StageId",
                table: "Appts");

            migrationBuilder.DropForeignKey(
                name: "FK_Appts_Types_TypeId",
                table: "Appts");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Appts_PatientId",
                table: "Appts");

            migrationBuilder.DropIndex(
                name: "IX_Appts_StageId",
                table: "Appts");

            migrationBuilder.DropIndex(
                name: "IX_Appts_TypeId",
                table: "Appts");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Appts");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Appts");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "Appts");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Appts");
        }
    }
}
