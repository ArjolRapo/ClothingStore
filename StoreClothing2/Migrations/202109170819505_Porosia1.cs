namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Porosia1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Porosias", "ProduktID", c => c.Int(nullable: false));
            AddColumn("dbo.Porosias", "IDuser", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Porosias", "IDuser");
            DropColumn("dbo.Porosias", "ProduktID");
        }
    }
}
