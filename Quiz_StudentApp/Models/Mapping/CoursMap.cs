using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Quiz_StudentApp.Models.Mapping
{
    public class CoursMap : EntityTypeConfiguration<Course>
    {
        public CoursMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Courses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.EducationId_Id).HasColumnName("EducationId_Id");

            // Relationships
            this.HasMany(t => t.Users)
                .WithMany(t => t.Courses)
                .Map(m =>
                    {
                        m.ToTable("UserCourse1");
                        m.MapLeftKey("Course_Id");
                        m.MapRightKey("User_Id");
                    });

            this.HasOptional(t => t.Education)
                .WithMany(t => t.Courses)
                .HasForeignKey(d => d.EducationId_Id);

        }
    }
}
