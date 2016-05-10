using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Quiz_StudentApp.Models.Mapping;

namespace Quiz_StudentApp.Models
{
    public partial class QuizContext : DbContext
    {
        static QuizContext()
        {
            Database.SetInitializer<QuizContext>(null);
        }

        public QuizContext()
            : base("Name=Quiz_WPFVersionDataQuizContextContext")
        {
        }

        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlternativeMap());
            modelBuilder.Configurations.Add(new CoursMap());
            modelBuilder.Configurations.Add(new EducationMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new QuizMap());
            modelBuilder.Configurations.Add(new ResultMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
