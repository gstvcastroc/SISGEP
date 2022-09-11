using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGEP.Application.Data.Mappings
{
    public class QuestionnaireMap : IEntityTypeConfiguration<Questionnaire>
    {
        public void Configure(EntityTypeBuilder<Questionnaire> builder)
        {
            builder.ToTable("questionnaires");

            builder
                .HasKey(questionnaire => questionnaire.Id);

            builder
                .Property(questionnaire => questionnaire.Id);

            builder
                .Property(questionnaire => questionnaire.Name)
                .HasColumnType("varchar(32)")
                .IsRequired();

            builder
                .Property(questionnaire => questionnaire.Date)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(questionnaire => questionnaire.Structure)
                .HasColumnType("json")
                .IsRequired();

            builder
                .HasMany(questionnaire => questionnaire.AnsweredQuestionnaires)
                .WithOne(answer => answer.Questionnaire);
        }
    }
}
