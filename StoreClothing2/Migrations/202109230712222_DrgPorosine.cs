namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrgPorosine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrgPorosias", "Produkti_IDProdukte", c => c.Int());
            CreateIndex("dbo.DrgPorosias", "Produkti_IDProdukte");
            AddForeignKey("dbo.DrgPorosias", "Produkti_IDProdukte", "dbo.Produktes", "IDProdukte");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrgPorosias", "Produkti_IDProdukte", "dbo.Produktes");
            DropIndex("dbo.DrgPorosias", new[] { "Produkti_IDProdukte" });
            DropColumn("dbo.DrgPorosias", "Produkti_IDProdukte");
        }
    }
}
