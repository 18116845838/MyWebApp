namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "CreateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "CreateTime");
        }
    }
}
