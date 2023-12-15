namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contact_communucation_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeCommunications",
                c => new
                    {
                        communucationID = c.Int(nullable: false, identity: true),
                        phone = c.String(),
                        email = c.String(),
                        adresinfo = c.String(),
                    })
                .PrimaryKey(t => t.communucationID);
            
            CreateTable(
                "dbo.HomeContacts",
                c => new
                    {
                        contactID = c.Int(nullable: false, identity: true),
                        nameSurname = c.String(),
                        email = c.String(),
                        subject = c.String(),
                        messagetext = c.String(),
                    })
                .PrimaryKey(t => t.contactID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HomeContacts");
            DropTable("dbo.HomeCommunications");
        }
    }
}
