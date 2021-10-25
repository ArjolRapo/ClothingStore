namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrgPorosi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrgPorosias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Emri = c.String(),
                        Mbiemri = c.String(),
                        Rruga = c.String(),
                        Qyteti = c.String(),
                        Shteti = c.String(),
                        KodiPostal = c.Int(nullable: false),
                        Telefon = c.String(),
                        Inventar_IDinventari = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventaris", t => t.Inventar_IDinventari)
                .Index(t => t.Inventar_IDinventari);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrgPorosias", "Inventar_IDinventari", "dbo.Inventaris");
            DropIndex("dbo.DrgPorosias", new[] { "Inventar_IDinventari" });
            DropTable("dbo.DrgPorosias");
        }
    }
}
