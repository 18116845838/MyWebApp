namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Icon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Icon");
        }
    }
}
