namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shporta4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Shportas", name: "Produkte_IDProdukte", newName: "Produkti_IDProdukte");
            RenameIndex(table: "dbo.Shportas", name: "IX_Produkte_IDProdukte", newName: "IX_Produkti_IDProdukte");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Shportas", name: "IX_Produkti_IDProdukte", newName: "IX_Produkte_IDProdukte");
            RenameColumn(table: "dbo.Shportas", name: "Produkti_IDProdukte", newName: "Produkte_IDProdukte");
        }
    }
}
