using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Quiz_StudentApp.Models.Mapping
{
    public class QuizMap : EntityTypeConfiguration<Quiz>
    {
        public QuizMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Quizs");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.GScore).HasColumnName("GScore");
            this.Property(t => t.VGScore).HasColumnName("VGScore");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.TimeLimit).HasColumnName("TimeLimit");
            this.Property(t => t.ShowStudentResult).HasColumnName("ShowStudentResult");
            this.Property(t => t.SentToAdmin).HasColumnName("SentToAdmin");
            this.Property(t => t.SentToStudent).HasColumnName("SentToStudent");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.Quizs)
                .HasForeignKey(d => d.UserId);

        }
    }
}
