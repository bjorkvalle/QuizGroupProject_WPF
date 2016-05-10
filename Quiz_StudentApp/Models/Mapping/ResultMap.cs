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
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.Quiz_Id).HasColumnName("Quiz_Id");
            this.Property(t => t.Quiz_Id1).HasColumnName("Quiz_Id1");
            this.Property(t => t.User_Id1).HasColumnName("User_Id1");

            // Relationships
            this.HasOptional(t => t.Quiz)
                .WithMany(t => t.Results)
                .HasForeignKey(d => d.Quiz_Id1);
            this.HasOptional(t => t.User)
                .WithMany(t => t.Results)
                .HasForeignKey(d => d.User_Id1);

        }
    }
}
