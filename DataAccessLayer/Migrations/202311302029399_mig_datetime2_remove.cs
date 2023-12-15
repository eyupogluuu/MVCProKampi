﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_datetime2_remove : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Headings", "headindDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Headings", "headindDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
