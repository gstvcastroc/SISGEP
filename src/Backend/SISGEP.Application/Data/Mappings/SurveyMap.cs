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
    public class SurveyMap : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("surveys");

            builder
                .HasKey(survey => survey.SurveyId);

            builder
                .Property(survey => survey.SurveyId);

            builder
                .Property(survey => survey.Name)
                .HasColumnType("varchar(32)")
                .IsRequired();

            builder
                .Property(survey => survey.Date)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(survey => survey.Structure)
                .HasColumnType("json")
                .IsRequired();
        }
    }
}
