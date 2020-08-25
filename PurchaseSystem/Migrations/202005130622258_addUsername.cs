namespace PurchaseSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUsername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductMsts", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductMsts", "UserName");
        }
    }
}
