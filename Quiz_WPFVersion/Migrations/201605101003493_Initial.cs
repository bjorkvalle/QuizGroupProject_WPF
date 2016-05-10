namespace Quiz_WPFVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserCourses", newName: "CourseUsers");
            DropForeignKey("dbo.Questions", "Quiz_Id", "dbo.Quizs");
            DropIndex("dbo.Questions", new[] { "Quiz_Id" });
            DropPrimaryKey("dbo.CourseUsers");
            AddColumn("dbo.Alternatives", "AnsweredValue", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Quiz_Id1", c => c.Int());
            AddPrimaryKey("dbo.CourseUsers", new[] { "Course_Id", "User_Id" });
            CreateIndex("dbo.Questions", "Quiz_Id1");
            AddForeignKey("dbo.Questions", "Quiz_Id1", "dbo.Quizs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Quiz_Id1", "dbo.Quizs");
            DropIndex("dbo.Questions", new[] { "Quiz_Id1" });
            DropPrimaryKey("dbo.CourseUsers");
            DropColumn("dbo.Questions", "Quiz_Id1");
            DropColumn("dbo.Alternatives", "AnsweredValue");
            AddPrimaryKey("dbo.CourseUsers", new[] { "User_Id", "Course_Id" });
            CreateIndex("dbo.Questions", "Quiz_Id");
            AddForeignKey("dbo.Questions", "Quiz_Id", "dbo.Quizs", "Id");
            RenameTable(name: "dbo.CourseUsers", newName: "UserCourses");
        }
    }
}
