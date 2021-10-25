namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shporta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shportas",
                c => new
                    {
                        IDShoprta = c.Int(nullable: false, identity: true),
                        Sasia = c.Int(nullable: false),
                        Produkte_IDProdukte = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDShoprta)
                .ForeignKey("dbo.Produktes", t => t.Produkte_IDProdukte)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Produkte_IDProdukte)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shportas", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shportas", "Produkte_IDProdukte", "dbo.Produktes");
            DropIndex("dbo.Shportas", new[] { "User_Id" });
            DropIndex("dbo.Shportas", new[] { "Produkte_IDProdukte" });
            DropTable("dbo.Shportas");
        }
    }
}
