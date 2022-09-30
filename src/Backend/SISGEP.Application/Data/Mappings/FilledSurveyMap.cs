using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISGEP.Application.Entities;

namespace SISGEP.Application.Data.Mappings
{
    public class FilledSurveyMap : IEntityTypeConfiguration<FilledSurvey>
    {
        public void Configure(EntityTypeBuilder<FilledSurvey> builder)
        {
            builder.ToTable("filled-surveys");

            builder
                .HasKey(filledSurvey => filledSurvey.FilledSurveyId);

            builder
                .Property(filledSurvey => filledSurvey.FilledSurveyId);

            builder
                .Property(filledSurvey => filledSurvey.Structure)
                .HasColumnType("json")
                .IsRequired();

            builder
                .Property(filledSurvey => filledSurvey.Date)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
