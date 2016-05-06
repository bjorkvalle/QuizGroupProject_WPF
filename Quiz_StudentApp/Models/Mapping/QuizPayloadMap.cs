using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Quiz_StudentApp.Models.Mapping
{
    public class QuizPayloadMap : EntityTypeConfiguration<QuizPayload>
    {
        public QuizPayloadMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("QuizPayloads");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SentToAdmin).HasColumnName("SentToAdmin");
            this.Property(t => t.SentToStudent).HasColumnName("SentToStudent");
            this.Property(t => t.QuizId_Id).HasColumnName("QuizId_Id");
            this.Property(t => t.UserId_Id).HasColumnName("UserId_Id");

            // Relationships
            this.HasOptional(t => t.Quiz)
                .WithMany(t => t.QuizPayloads)
                .HasForeignKey(d => d.QuizId_Id);
            this.HasOptional(t => t.User)
                .WithMany(t => t.QuizPayloads)
                .HasForeignKey(d => d.UserId_Id);

        }
    }
}
