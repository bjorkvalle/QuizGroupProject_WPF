using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Quiz_StudentApp.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.EducationId).HasColumnName("EducationId");

            // Relationships
            this.HasOptional(t => t.Education)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.EducationId);

        }
    }
}
