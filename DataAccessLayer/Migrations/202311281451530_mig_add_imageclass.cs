namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_imageclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        imageID = c.Int(nullable: false, identity: true),
                        imageName = c.String(maxLength: 50),
                        imagePath = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.imageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Images");
        }
    }
}
