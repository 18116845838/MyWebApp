namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arcticles", "Author_Id", c => c.Int());
            CreateIndex("dbo.Arcticles", "Author_Id");
            AddForeignKey("dbo.Arcticles", "Author_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arcticles", "Author_Id", "dbo.Users");
            DropIndex("dbo.Arcticles", new[] { "Author_Id" });
            DropColumn("dbo.Arcticles", "Author_Id");
        }
    }
}
