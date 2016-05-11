namespace Quiz_StudentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Questions", name: "Quiz_Id", newName: "QuizId");
            RenameColumn(table: "dbo.UserCourses", name: "Course_Id", newName: "CourseId");
            RenameColumn(table: "dbo.UserCourses", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Users", name: "Education_Id", newName: "EducationId");
            RenameColumn(table: "dbo.Results", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Results", name: "Quiz_Id", newName: "QuizId");
            RenameIndex(table: "dbo.Questions", name: "IX_Quiz_Id", newName: "IX_QuizId");
            RenameIndex(table: "dbo.Users", name: "IX_Education_Id", newName: "IX_EducationId");
            RenameIndex(table: "dbo.Results", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.Results", name: "IX_Quiz_Id", newName: "IX_QuizId");
            RenameIndex(table: "dbo.UserCourses", name: "IX_Course_Id", newName: "IX_CourseId");
            RenameIndex(table: "dbo.UserCourses", name: "IX_User_Id", newName: "IX_UserId");
            AlterColumn("dbo.Quizs", "TimeLimit", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quizs", "TimeLimit", c => c.Time(nullable: false, precision: 7));
            RenameIndex(table: "dbo.UserCourses", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.UserCourses", name: "IX_CourseId", newName: "IX_Course_Id");
            RenameIndex(table: "dbo.Results", name: "IX_QuizId", newName: "IX_Quiz_Id");
            RenameIndex(table: "dbo.Results", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Users", name: "IX_EducationId", newName: "IX_Education_Id");
            RenameIndex(table: "dbo.Questions", name: "IX_QuizId", newName: "IX_Quiz_Id");
            RenameColumn(table: "dbo.Results", name: "QuizId", newName: "Quiz_Id");
            RenameColumn(table: "dbo.Results", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Users", name: "EducationId", newName: "Education_Id");
            RenameColumn(table: "dbo.UserCourses", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.UserCourses", name: "CourseId", newName: "Course_Id");
            RenameColumn(table: "dbo.Questions", name: "QuizId", newName: "Quiz_Id");
        }
    }
}
