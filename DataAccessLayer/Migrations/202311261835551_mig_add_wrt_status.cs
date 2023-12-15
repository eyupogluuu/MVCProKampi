namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_wrt_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "writerStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "writerStatus");
        }
    }
}
