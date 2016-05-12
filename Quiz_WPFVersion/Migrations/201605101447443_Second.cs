namespace Quiz_WPFVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
