namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inventari : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventaris",
                c => new
                    {
                        IDinventari = c.Int(nullable: false, identity: true),
                        SasiTotale = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDinventari);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inventaris");
        }
    }
}
