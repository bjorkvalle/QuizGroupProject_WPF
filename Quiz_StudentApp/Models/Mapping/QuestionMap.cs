using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Quiz_StudentApp.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Questions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.QuizId).HasColumnName("QuizId");

            // Relationships
            this.HasOptional(t => t.Quiz)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.QuizId);

        }
    }
}
