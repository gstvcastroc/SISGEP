using Bogus;
using Bogus.Extensions.Brazil;
using CountryData.Bogus;
using SISGEP.Application.Data;
using SISGEP.Application.Data.Repositories;
using SISGEP.Application.DTOs;
using SISGEP.Application.Entities;
using SISGEP.Application.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEP.Seed
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var context = new SISGEPContext();

            var persons = context.Persons;

            context.RemoveRange(persons);

            await context.SaveChangesAsync();

            var faker = new Faker<EditPersonDTO>(locale: "pt_BR")
                .RuleFor(person => person.Name, faker => $"{faker.Name.FirstName()} {faker.Name.LastName()}")
                .RuleFor(person => person.Email, (faker, person) => faker.Internet.Email(
                    firstName: person.Name.Split(" ").FirstOrDefault(),
                    lastName: person.Name.Split(" ").LastOrDefault()))
                .RuleFor(person => person.Password, faker => faker.Random.ReplaceNumbers("####"))
                .RuleFor(person => person.IsActive, faker => faker.Random.Bool())
                .RuleFor(person => person.Cpf, faker => faker.Person.Cpf().Replace(".", "").Replace("-", ""))
                .RuleFor(person => person.PersonType, faker => faker.PickRandom<PersonType>())
                .RuleFor(person => person.Address, faker => new AddressDTO()
                {
                    PostalCode = faker.Random.ReplaceNumbers("########"),
                    Thoroughfare = $"{faker.Address.StreetSuffix()} {faker.Address.StreetName().Split(" ").FirstOrDefault()}",
                    Number = int.Parse(faker.Random.ReplaceNumbers("####")),
                    Complement = faker.Address.SecondaryAddress(),
                    City = faker.Address.City(),
                    State = faker.Country().Brazil().State().Name
                });

            var personList = faker.Generate(100);

            var personService = new PersonService(context, new Repository<Application.Entities.Person>(context));

            foreach (var person in personList)
            {
                await personService.CreatePersonAsync(person);
            }

            Console.WriteLine("Todos os registros foram adicionados com sucesso.");

            Console.ReadLine();
        }
    }
}