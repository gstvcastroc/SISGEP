using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SISGEP.Application.Contracts;
using SISGEP.Application.Data;
using SISGEP.Application.Data.Repositories;
using SISGEP.Application.Entities;
using SISGEP.Application.Services;

namespace SISGEP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                "Any",
                cors =>
                {
                    cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SISGEPContext>();

            builder.Services.AddScoped<IProjectService, ProjectService>();

            builder.Services.AddScoped<IPersonService, PersonService>();

            builder.Services.AddScoped<ISurveyService, SurveyService>();

            builder.Services.AddScoped<IRepository<Person>, Repository<Person>>();

            builder.Services.AddScoped<IRepository<Project>, Repository<Project>>();

            builder.Services.AddScoped<IRepository<Survey>, Repository<Survey>>();

            builder.Services.AddScoped<IRepository<FilledSurvey>, Repository<FilledSurvey>>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("Any");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}