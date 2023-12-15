namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_admin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        adminID = c.Int(nullable: false, identity: true),
                        adminUsername = c.String(maxLength: 20),
                        passeord = c.String(maxLength: 10),
                        role = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.adminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
