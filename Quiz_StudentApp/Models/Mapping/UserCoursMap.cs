using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Quiz_StudentApp.Models.Mapping
{
    public class UserCoursMap : EntityTypeConfiguration<UserCourse>
    {
        public UserCoursMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserCourses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.QuizId_Id).HasColumnName("QuizId_Id");
            this.Property(t => t.UserId_Id).HasColumnName("UserId_Id");

            // Relationships
            this.HasOptional(t => t.Quiz)
                .WithMany(t => t.UserCourses)
                .HasForeignKey(d => d.QuizId_Id);
            this.HasOptional(t => t.User)
                .WithMany(t => t.UserCourses)
                .HasForeignKey(d => d.UserId_Id);

        }
    }
}
