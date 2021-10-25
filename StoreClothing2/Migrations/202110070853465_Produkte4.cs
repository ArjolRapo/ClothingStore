namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produkte4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produktes", "Sasi", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produktes", "Sasi");
        }
    }
}
