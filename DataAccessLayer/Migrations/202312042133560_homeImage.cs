namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class homeImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeImages",
                c => new
                    {
                        himageID = c.Int(nullable: false, identity: true),
                        tittle = c.String(),
                        imageUrl = c.String(),
                    })
                .PrimaryKey(t => t.himageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HomeImages");
        }
    }
}
