using Bogus;
using SISGEP.Application.Data.Repositories;
using SISGEP.Application.Data;
using SISGEP.Application.DTOs;
using SISGEP.Application.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using SISGEP.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace SISGEP.Seed
{
    internal class ProjectSeed
    {
        internal static async Task Execute()
        {
            using var context = new SISGEPContext();

            var projects = context.Projects;

            Console.WriteLine("Limpando os projetos do banco de dados...");

            context.RemoveRange(projects);

            await context.SaveChangesAsync();

            var faker = new Faker<EditProjectDTO>(locale: "pt_BR")
                .RuleFor(project => project.Name, faker => $"Projeto {faker.Address.City()}")
                .RuleFor(project => project.Description, faker => faker.Lorem.Sentence())
                .RuleFor(project => project.IsActive, faker => true)
                .RuleFor(project => project.StartDate, faker => faker.Date.Past(1, DateTime.Now))
                .RuleFor(project => project.EndDate, faker => null);

            const int quantity = 100;

            var editProjectDto = faker.Generate(quantity);

            var projectService = new ProjectService(context, new Repository<Project>(context));

            var surveyService = new SurveyService(
                context,
                new Repository<Survey>(context),
                new Repository<FilledSurvey>(context));

            int c = 0;

            foreach (var project in editProjectDto)
            {
                c++;
                await projectService.CreateProjectAsync(project);

                Console.WriteLine($"Criando o projeto {project.Name}. {c}/{quantity}.");
            }

            var projectsList = context.Projects.ToList();

            var personList = context.Persons.ToList();

            var random = new Random();

            foreach (var project in projectsList)
            {
                Console.WriteLine($"Criando o questionário do projeto {project.Name}...");

                await surveyService.CreateSurveyAsync(new EditSurveyDTO()
                {
                    Name = $"{project.Name}",
                    Date = project.StartDate,
                    Structure = "{}",
                    ProjectId = project.ProjectId,
                });

                var selectedPersons = personList
                    .Skip(random.Next(0, personList.Count))
                    .Take(random.Next(0, 10))
                    .ToList();

                Console.WriteLine("Populando os questionários respondidos...");

                foreach (var person in selectedPersons)
                {
                    await surveyService.FillSurvey(new EditFilledSurveyDTO()
                    {
                        SurveyId = project.ProjectId,
                        PersonId = person.PersonId,
                        Structure = "{}",
                        Date = (DateTime)project.StartDate
                    });
                }

            }

            await context.SaveChangesAsync();

            Console.WriteLine("Todos os registros de projetos e questionários foram adicionados com sucesso.");

            Console.ReadLine();
        }
    }
}
