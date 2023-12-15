namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_whatıdo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WhatIDoes",
                c => new
                    {
                        whatIDoID = c.Int(nullable: false, identity: true),
                        tittle = c.String(),
                        descreption = c.String(),
                    })
                .PrimaryKey(t => t.whatIDoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WhatIDoes");
        }
    }
}
