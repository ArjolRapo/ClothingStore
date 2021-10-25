namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produkte3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produktes", "Cmimi", c => c.Decimal(nullable: true, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produktes", "Cmimi", c => c.String());
        }
    }
}
