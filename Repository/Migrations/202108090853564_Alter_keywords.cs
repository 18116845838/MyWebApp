namespace Repository.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class Alter_keywords : DbMigration
	{
		public override void Up()
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
			DropForeignKey("dbo.Keywords", "Content_Id", "dbo.Contents");
			DropIndex("dbo.Keywords", new[] { "Content_Id" });
			CreateTable(
				"dbo.KeywordContents",
				c => new
				{
					Keyword_Id = c.Int(nullable: false),
					Content_Id = c.Int(nullable: false),
				})
				.PrimaryKey(t => new { t.Keyword_Id, t.Content_Id })
				.ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
				.ForeignKey("dbo.Contents", t => t.Content_Id, cascadeDelete: true)
				.Index(t => t.Keyword_Id)
				.Index(t => t.Content_Id);

			DropColumn("dbo.Keywords", "Content_Id");
		}

		public override void Down()
		{
			AddColumn("dbo.Keywords", "Content_Id", c => c.Int());
			DropForeignKey("dbo.KeywordContents", "Content_Id", "dbo.Contents");
			DropForeignKey("dbo.KeywordContents", "Keyword_Id", "dbo.Keywords");
			DropIndex("dbo.KeywordContents", new[] { "Content_Id" });
			DropIndex("dbo.KeywordContents", new[] { "Keyword_Id" });
			DropTable("dbo.KeywordContents");
			CreateIndex("dbo.Keywords", "Content_Id");
			AddForeignKey("dbo.Keywords", "Content_Id", "dbo.Contents", "Id");
		}
	}
}
