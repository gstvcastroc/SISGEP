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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", nullable: false),
                    Password = table.Column<string>(type: "varchar(256)", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(9)", nullable: false),
                    PersonType = table.Column<string>(type: "varchar(9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(32)", nullable: false),
                    Description = table.Column<string>(type: "varchar(256)", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    Thoroughfare = table.Column<string>(type: "varchar(256)", nullable: false),
                    Number = table.Column<int>(type: "smallserial", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(64)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(128)", nullable: false),
                    City = table.Column<string>(type: "varchar(64)", nullable: false),
                    State = table.Column<string>(type: "varchar(16)", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonProject",
                columns: table => new
                {
                    PersonsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProject", x => new { x.PersonsId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_PersonProject_persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonProject_projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questionnaires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(32)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Structure = table.Column<string>(type: "json", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionnaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questionnaires_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answered-questionnaires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Structure = table.Column<string>(type: "json", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    QuestionnaireId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answered-questionnaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_answered-questionnaires_questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnsweredQuestionnairePerson",
                columns: table => new
                {
                    AnswersId = table.Column<Guid>(type: "uuid", nullable: false),
                    BenefitedsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnsweredQuestionnairePerson", x => new { x.AnswersId, x.BenefitedsId });
                    table.ForeignKey(
                        name: "FK_AnsweredQuestionnairePerson_answered-questionnaires_Answers~",
                        column: x => x.AnswersId,
                        principalTable: "answered-questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnsweredQuestionnairePerson_persons_BenefitedsId",
                        column: x => x.BenefitedsId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_PersonId",
                table: "addresses",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_answered-questionnaires_QuestionnaireId",
                table: "answered-questionnaires",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_AnsweredQuestionnairePerson_BenefitedsId",
                table: "AnsweredQuestionnairePerson",
                column: "BenefitedsId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProject_ProjectsId",
                table: "PersonProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_questionnaires_ProjectId",
                table: "questionnaires",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "AnsweredQuestionnairePerson");

            migrationBuilder.DropTable(
                name: "PersonProject");

            migrationBuilder.DropTable(
                name: "answered-questionnaires");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "questionnaires");

            migrationBuilder.DropTable(
                name: "projects");
        }
    }
}
