namespace Quiz_WPFVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        ScoreValue = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Quiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.Quiz_Id)
                .Index(t => t.Quiz_Id);
            
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Type = c.Int(nullable: false),
                        Education_Id = c.Int(),
                        Education_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.Education_Id1)
                .Index(t => t.Education_Id1);
            
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
                        TimeLimit = c.Time(nullable: false, precision: 7),
                        ShowStudentResult = c.Boolean(nullable: false),
                        SentToAdmin = c.Boolean(nullable: false),
                        SentToStudent = c.Boolean(nullable: false),
                        UserId = c.Int(),
                        AverageTime = c.DateTime(),
                        GradeG = c.Int(),
                        GradeF = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        User_Id = c.Int(),
                        Quiz_Id = c.Int(),
                        Quiz_Id1 = c.Int(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.Quiz_Id1)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .Index(t => t.Quiz_Id1)
                .Index(t => t.User_Id1);
            
            CreateTable(
                "dbo.UserCourses",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Course_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Results", "Quiz_Id1", "dbo.Quizs");
            DropForeignKey("dbo.Quizs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "Quiz_Id", "dbo.Quizs");
            DropForeignKey("dbo.Users", "Education_Id1", "dbo.Educations");
            DropForeignKey("dbo.UserCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.UserCourses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Courses", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.Alternatives", "QuestionId", "dbo.Questions");
            DropIndex("dbo.UserCourses", new[] { "Course_Id" });
            DropIndex("dbo.UserCourses", new[] { "User_Id" });
            DropIndex("dbo.Results", new[] { "User_Id1" });
            DropIndex("dbo.Results", new[] { "Quiz_Id1" });
            DropIndex("dbo.Quizs", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Education_Id1" });
            DropIndex("dbo.Courses", new[] { "EducationId" });
            DropIndex("dbo.Questions", new[] { "Quiz_Id" });
            DropIndex("dbo.Alternatives", new[] { "QuestionId" });
            DropTable("dbo.UserCourses");
            DropTable("dbo.Results");
            DropTable("dbo.Quizs");
            DropTable("dbo.Users");
            DropTable("dbo.Educations");
            DropTable("dbo.Courses");
            DropTable("dbo.Questions");
            DropTable("dbo.Alternatives");
        }
    }
}
