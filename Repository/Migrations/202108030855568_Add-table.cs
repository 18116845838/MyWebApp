namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtable : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Keywords");
        }
    }
}
