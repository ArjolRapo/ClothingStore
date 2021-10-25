namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produkte : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produktes",
                c => new
                    {
                        IDProdukte = c.Int(nullable: false, identity: true),
                        Emri = c.String(),
                        Imazh = c.String(),
                        Cmimi = c.String(),
                        Pershkrimi = c.String(),
                        Inventari_IDinventari = c.Int(),
                        Kategori_IDKategori = c.Int(),
                    })
                .PrimaryKey(t => t.IDProdukte)
                .ForeignKey("dbo.Inventaris", t => t.Inventari_IDinventari)
                .ForeignKey("dbo.Kategoris", t => t.Kategori_IDKategori)
                .Index(t => t.Inventari_IDinventari)
                .Index(t => t.Kategori_IDKategori);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produktes", "Kategori_IDKategori", "dbo.Kategoris");
            DropForeignKey("dbo.Produktes", "Inventari_IDinventari", "dbo.Inventaris");
            DropIndex("dbo.Produktes", new[] { "Kategori_IDKategori" });
            DropIndex("dbo.Produktes", new[] { "Inventari_IDinventari" });
            DropTable("dbo.Produktes");
        }
    }
}
