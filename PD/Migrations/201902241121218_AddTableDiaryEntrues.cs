namespace PD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableDiaryEntrues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiaryEntries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Text = c.String(nullable: false, maxLength: 100),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiaryEntries", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.DiaryEntries", new[] { "UserId" });
            DropTable("dbo.DiaryEntries");
        }
    }
}
