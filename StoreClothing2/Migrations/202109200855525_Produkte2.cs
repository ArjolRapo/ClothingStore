namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produkte2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shportas", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Shportas", new[] { "User_Id" });
            DropColumn("dbo.Shportas", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shportas", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Shportas", "User_Id");
            AddForeignKey("dbo.Shportas", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
