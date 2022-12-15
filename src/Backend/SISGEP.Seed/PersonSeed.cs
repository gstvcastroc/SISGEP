using Bogus;
using Bogus.Extensions.Brazil;
using CountryData.Bogus;
using SISGEP.Application.Data.Repositories;
using SISGEP.Application.Data;
using SISGEP.Application.DTOs;
using SISGEP.Application.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using SISGEP.Application.Entities;

namespace SISGEP.Seed
{
    internal class PersonSeed
    {
        internal static async Task Execute()
        {
            var context = new SISGEPContext();

            var persons = context.Persons;

            Console.WriteLine("Limpando as pessoas do banco de dados...");

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

            const int quantity = 1000;

            var personList = faker.Generate(quantity);

            var personService = new PersonService(context, new Repository<Application.Entities.Person>(context));

            int c = 0;

            foreach (var person in personList)
            {
                c++;
                await personService.CreatePersonAsync(person);

                Console.WriteLine($"Criando a pessoa {person.Name}. {c}/{quantity}.");
            }

            Console.WriteLine("Todos os registros de pessoas foram adicionados com sucesso.");
        }
    }
}
