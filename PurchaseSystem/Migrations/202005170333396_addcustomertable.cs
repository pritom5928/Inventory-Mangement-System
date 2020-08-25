namespace PurchaseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcustomertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerMsts",
                c => new
                    {
                        pk_Cusid = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        UserName = c.String(),
                        Mobileno = c.String(),
                    })
                .PrimaryKey(t => t.pk_Cusid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerMsts");
        }
    }
}
