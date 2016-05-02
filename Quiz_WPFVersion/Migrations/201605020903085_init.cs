namespace Quiz_WPFVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Type = c.Int(nullable: false),
                        Quiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.Quiz_Id)
                .Index(t => t.Quiz_Id);
            
            CreateTable(
                "dbo.Alternatives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ScoreValue = c.Int(nullable: false),
                        questionId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.questionId_Id)
                .Index(t => t.questionId_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Type = c.Int(nullable: false),
                        EducationId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.EducationId_Id)
                .Index(t => t.EducationId_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EducationId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.EducationId_Id)
                .Index(t => t.EducationId_Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseUsers",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.User_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CourseUsers", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Users", "EducationId_Id", "dbo.Educations");
            DropForeignKey("dbo.Courses", "EducationId_Id", "dbo.Educations");
            DropForeignKey("dbo.Questions", "Quiz_Id", "dbo.Quizs");
            DropForeignKey("dbo.Alternatives", "questionId_Id", "dbo.Questions");
            DropIndex("dbo.CourseUsers", new[] { "User_Id" });
            DropIndex("dbo.CourseUsers", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "EducationId_Id" });
            DropIndex("dbo.Users", new[] { "EducationId_Id" });
            DropIndex("dbo.Alternatives", new[] { "questionId_Id" });
            DropIndex("dbo.Questions", new[] { "Quiz_Id" });
            DropTable("dbo.CourseUsers");
            DropTable("dbo.Educations");
            DropTable("dbo.Courses");
            DropTable("dbo.Users");
            DropTable("dbo.Alternatives");
            DropTable("dbo.Questions");
            DropTable("dbo.Quizs");
        }
    }
}
