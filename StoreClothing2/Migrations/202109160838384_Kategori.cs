namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kategori : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        IDKategori = c.Int(nullable: false, identity: true),
                        Emri = c.String(),
                        Imazh = c.String(),
                        Pershkrimi = c.String(),
                    })
                .PrimaryKey(t => t.IDKategori);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kategoris");
        }
    }
}
