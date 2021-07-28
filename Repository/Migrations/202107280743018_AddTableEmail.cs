namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableEmail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EMail = c.String(),
                        Code = c.String(),
                        HasValid = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "UserId", "dbo.Users");
            DropIndex("dbo.Emails", new[] { "UserId" });
            DropTable("dbo.Emails");
        }
    }
}
