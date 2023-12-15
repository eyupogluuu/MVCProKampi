namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_tittle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "writerTittle", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "writerTittle");
        }
    }
}
