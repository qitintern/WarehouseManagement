namespace WarehouseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CatFieldUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit = c.String(),
                        Street = c.String(),
                        State = c.String(),
                        Postcode = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Company");
        }
    }
}
