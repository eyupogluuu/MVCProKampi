namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_homeTestiimonial_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        testimonialID = c.Int(nullable: false, identity: true),
                        nameSurname = c.String(),
                        tittle = c.String(),
                        descreption = c.String(),
                    })
                .PrimaryKey(t => t.testimonialID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Testimonials");
        }
    }
}
