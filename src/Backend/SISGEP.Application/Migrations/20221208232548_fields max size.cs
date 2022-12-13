using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace SISGEP.Application.Migrations
{
    public partial class fieldsmaxsize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person-project");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "person",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "address",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)");

            migrationBuilder.CreateTable(
                name: "PersonProject",
                columns: table => new
                {
                    PersonsPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectsProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProject", x => new { x.PersonsPersonId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_PersonProject_person_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonProject_project_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonProject_ProjectsProjectId",
                table: "PersonProject",
                column: "ProjectsProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonProject");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "person",
                type: "varchar(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "address",
                type: "varchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.CreateTable(
                name: "person-project",
                columns: table => new
                {
                    PersonsPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectsProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person-project", x => new { x.PersonsPersonId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_person-project_person_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person-project_project_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person-project_ProjectsProjectId",
                table: "person-project",
                column: "ProjectsProjectId");
        }
    }
}
