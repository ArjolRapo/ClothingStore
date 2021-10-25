namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shporta5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shportas", "ProduktID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shportas", "ProduktID", c => c.Int(nullable: false));
        }
    }
}
