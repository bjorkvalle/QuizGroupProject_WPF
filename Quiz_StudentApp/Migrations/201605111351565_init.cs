namespace Quiz_StudentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alternatives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ScoreValue = c.Int(nullable: false),
                        AnsweredValue = c.Int(nullable: false),
                        QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Type = c.Int(nullable: false),
                        QuizId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.QuizId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        GScore = c.Int(nullable: false),
                        VGScore = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        TimeLimit = c.Time(precision: 7),
                        ShowStudentResult = c.Boolean(nullable: false),
                        SentToAdmin = c.Boolean(nullable: false),
                        SentToStudent = c.Boolean(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Type = c.Int(nullable: false),
                        EducationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.EducationId)
                .Index(t => t.EducationId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EducationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.EducationId)
                .Index(t => t.EducationId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        UserId = c.Int(),
                        QuizId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.QuizId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.UserCourses",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.UserId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alternatives", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.Quizs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Results", "UserId", "dbo.Users");
            DropForeignKey("dbo.Results", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.Users", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.UserCourses", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "EducationId", "dbo.Educations");
            DropIndex("dbo.UserCourses", new[] { "UserId" });
            DropIndex("dbo.UserCourses", new[] { "CourseId" });
            DropIndex("dbo.Results", new[] { "QuizId" });
            DropIndex("dbo.Results", new[] { "UserId" });
            DropIndex("dbo.Courses", new[] { "EducationId" });
            DropIndex("dbo.Users", new[] { "EducationId" });
            DropIndex("dbo.Quizs", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "QuizId" });
            DropIndex("dbo.Alternatives", new[] { "QuestionId" });
            DropTable("dbo.UserCourses");
            DropTable("dbo.Results");
            DropTable("dbo.Educations");
            DropTable("dbo.Courses");
            DropTable("dbo.Users");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.Alternatives");
        }
    }
}
