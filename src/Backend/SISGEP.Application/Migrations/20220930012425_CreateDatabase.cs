using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SISGEP.Application.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
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
                    table.PrimaryKey("PK_persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "projects",
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
                    table.PrimaryKey("PK_projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
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
                    table.PrimaryKey("PK_addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_addresses_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
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
                    table.PrimaryKey("PK_PersonProject", x => new { x.PersonsPersonId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_PersonProject_persons_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonProject_projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "surveys",
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
                    table.PrimaryKey("PK_surveys", x => x.SurveyId);
                    table.ForeignKey(
                        name: "FK_surveys_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "filled-surveys",
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
                    table.PrimaryKey("PK_filled-surveys", x => x.FilledSurveyId);
                    table.ForeignKey(
                        name: "FK_filled-surveys_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_filled-surveys_surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_PersonId",
                table: "addresses",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_filled-surveys_PersonId",
                table: "filled-surveys",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_filled-surveys_SurveyId",
                table: "filled-surveys",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProject_ProjectsProjectId",
                table: "PersonProject",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_surveys_ProjectId",
                table: "surveys",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "filled-surveys");

            migrationBuilder.DropTable(
                name: "PersonProject");

            migrationBuilder.DropTable(
                name: "surveys");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "projects");
        }
    }
}
