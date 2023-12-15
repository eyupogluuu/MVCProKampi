namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_admin_password : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "password", c => c.String(maxLength: 10));
            DropColumn("dbo.Admins", "passeord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "passeord", c => c.String(maxLength: 10));
            DropColumn("dbo.Admins", "password");
        }
    }
}
