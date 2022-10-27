using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SISGEP.Application.Migrations
{
    public partial class createDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", nullable: false),
                    Password = table.Column<string>(type: "varchar(256)", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(9)", nullable: false),
                    PersonType = table.Column<string>(type: "varchar(9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(32)", nullable: false),
                    Description = table.Column<string>(type: "varchar(256)", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    Thoroughfare = table.Column<string>(type: "varchar(256)", nullable: false),
                    Number = table.Column<int>(type: "smallserial", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(64)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(128)", nullable: true),
                    City = table.Column<string>(type: "varchar(64)", nullable: false),
                    State = table.Column<string>(type: "varchar(16)", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_address_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "survey",
                columns: table => new
                {
                    SurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(32)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Structure = table.Column<string>(type: "json", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey", x => x.SurveyId);
                    table.ForeignKey(
                        name: "FK_survey_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "filled-survey",
                columns: table => new
                {
                    FilledSurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Structure = table.Column<string>(type: "json", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filled-survey", x => x.FilledSurveyId);
                    table.ForeignKey(
                        name: "FK_filled-survey_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_filled-survey_survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "survey",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_PersonId",
                table: "address",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_filled-survey_PersonId",
                table: "filled-survey",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_filled-survey_SurveyId",
                table: "filled-survey",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_person-project_ProjectsProjectId",
                table: "person-project",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_survey_ProjectId",
                table: "survey",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "filled-survey");

            migrationBuilder.DropTable(
                name: "person-project");

            migrationBuilder.DropTable(
                name: "survey");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "project");
        }
    }
}
