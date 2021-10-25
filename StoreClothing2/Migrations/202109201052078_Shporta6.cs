namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shporta6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Shportas", "ProduktID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shportas", "ProduktID", c => c.Int());
        }
    }
}
