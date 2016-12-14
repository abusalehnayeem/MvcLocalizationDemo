namespace MvcLocalizationDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedResourceEntry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResourceEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Value = c.String(nullable: false, maxLength: 150),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResourceEntries");
        }
    }
}
