namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shporta1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shportas", "IdPerdorues", c => c.String());
            DropColumn("dbo.Shportas", "KategoriID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shportas", "KategoriID", c => c.Int());
            DropColumn("dbo.Shportas", "IdPerdorues");
        }
    }
}
