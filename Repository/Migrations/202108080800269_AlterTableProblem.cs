namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableProblem : DbMigration
    {
        public override void Up()
        {
   
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        PublishTime = c.DateTime(nullable: false),
                        Answer = c.Int(),
                        Summary = c.Int(),
                        Reward = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            DropTable("dbo.Keywords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Keyword = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Keywords", "Content_Id", "dbo.Contents");
            DropForeignKey("dbo.Contents", "Author_Id", "dbo.Users");
            DropIndex("dbo.Contents", new[] { "Author_Id" });
            DropIndex("dbo.Keywords", new[] { "Content_Id" });
            DropTable("dbo.Contents");
            DropTable("dbo.Keywords");
        }
    }
}
