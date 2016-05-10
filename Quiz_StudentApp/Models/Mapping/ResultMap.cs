using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Quiz_StudentApp.Models.Mapping
{
    public class ResultMap : EntityTypeConfiguration<Result>
    {
        public ResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Results");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Score).HasColumnName("Score");
            this.Property(t => t.QuizId).HasColumnName("QuizId");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.Results)
                .HasForeignKey(d => d.UserId);

        }
    }
}
