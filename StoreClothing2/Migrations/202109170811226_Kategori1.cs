namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kategori1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produktes", "KategoriID", c => c.Int());
            AddColumn("dbo.Produktes", "InventarID", c => c.Int(nullable: false));
            AddColumn("dbo.Shportas", "ProduktID", c => c.Int());
            AddColumn("dbo.Shportas", "KategoriID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shportas", "KategoriID");
            DropColumn("dbo.Shportas", "ProduktID");
            DropColumn("dbo.Produktes", "InventarID");
            DropColumn("dbo.Produktes", "KategoriID");
        }
    }
}
