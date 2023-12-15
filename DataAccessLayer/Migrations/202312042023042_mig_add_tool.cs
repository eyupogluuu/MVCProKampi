namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_tool : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        toolID = c.Int(nullable: false, identity: true),
                        toolName = c.String(),
                        toolRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.toolID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tools");
        }
    }
}
