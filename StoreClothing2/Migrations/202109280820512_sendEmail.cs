namespace StoreClothing2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sendEmail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.sendEmails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ToEmail = c.String(nullable: false),
                        EMailBody = c.String(),
                        EmailSubject = c.String(),
                        EmailCC = c.String(),
                        EmailBCC = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.sendEmails");
        }
    }
}
