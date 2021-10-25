namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Porosia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Porosias",
                c => new
                    {
                        IDPorosia = c.Int(nullable: false, identity: true),
                        Sasi = c.Int(nullable: false),
                        Produkte_IDProdukte = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDPorosia)
                .ForeignKey("dbo.Produktes", t => t.Produkte_IDProdukte)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Produkte_IDProdukte)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Porosias", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Porosias", "Produkte_IDProdukte", "dbo.Produktes");
            DropIndex("dbo.Porosias", new[] { "User_Id" });
            DropIndex("dbo.Porosias", new[] { "Produkte_IDProdukte" });
            DropTable("dbo.Porosias");
        }
    }
}
