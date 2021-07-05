namespace EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_TableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Register");
            RenameColumn(table: "dbo.Register", name: "Name", newName: "UserName");
            AddColumn("dbo.Register", "Age", c => c.Int());
            AddColumn("dbo.Register", "Enroll", c => c.DateTime());
            AddColumn("dbo.Register", "IsFemale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Register", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Register", "CreateTime", c => c.DateTime());
            AddColumn("dbo.Register", "EmailId", c => c.Int());
            AddColumn("dbo.Register", "Wallet", c => c.Int(nullable: false));
            AlterColumn("dbo.Register", "UserName", c => c.String(maxLength: 256));
            CreateIndex("dbo.Register", "CreateTime");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Register", new[] { "CreateTime" });
            AlterColumn("dbo.Register", "UserName", c => c.String());
            DropColumn("dbo.Register", "Wallet");
            DropColumn("dbo.Register", "EmailId");
            DropColumn("dbo.Register", "CreateTime");
            DropColumn("dbo.Register", "Password");
            DropColumn("dbo.Register", "IsFemale");
            DropColumn("dbo.Register", "Enroll");
            DropColumn("dbo.Register", "Age");
            RenameColumn(table: "dbo.Register", name: "UserName", newName: "Name");
            RenameTable(name: "dbo.Register", newName: "Users");
        }
    }
}
