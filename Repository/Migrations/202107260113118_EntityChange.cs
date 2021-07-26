namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityChange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Arcticles", newName: "Articles");
            AddColumn("dbo.Users", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Articles", "CreateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "CreateTime");
            DropColumn("dbo.Users", "CreateTime");
            RenameTable(name: "dbo.Articles", newName: "Arcticles");
        }
    }
}
