using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Quiz_StudentApp.Models.Mapping
{
    public class AlternativeMap : EntityTypeConfiguration<Alternative>
    {
        public AlternativeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Alternatives");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.ScoreValue).HasColumnName("ScoreValue");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");

            // Relationships
            this.HasOptional(t => t.Question)
                .WithMany(t => t.Alternatives)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
