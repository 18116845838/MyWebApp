namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Entity_ArticleAndComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        commend = c.Int(nullable: false),
                        notRecommend = c.Int(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        commend = c.Int(nullable: false),
                        notRecommend = c.Int(nullable: false),
                        Author_Id = c.Int(),
                        Comment_Id = c.Int(),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Comment_Id)
                .Index(t => t.Article_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Comments", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Articles", "Author_Id", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "Article_Id" });
            DropIndex("dbo.Comments", new[] { "Comment_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.Articles", new[] { "Author_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
        }
    }
}
