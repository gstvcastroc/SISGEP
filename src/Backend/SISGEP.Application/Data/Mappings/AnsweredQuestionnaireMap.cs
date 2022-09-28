using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISGEP.Application.Entities;

namespace SISGEP.Application.Data.Mappings
{
    public class AnsweredQuestionnaireMap : IEntityTypeConfiguration<AnsweredQuestionnaire>
    {
        public void Configure(EntityTypeBuilder<AnsweredQuestionnaire> builder)
        {
            builder.ToTable("answered-questionnaires");

            builder
                .HasKey(questionnaire => questionnaire.Id);

            builder
                .Property(questionnaire => questionnaire.Id);

            builder
                .Property(questionnaire => questionnaire.Structure)
                .HasColumnType("json")
                .IsRequired();

            builder
                .Property(questionnaire => questionnaire.Date)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
