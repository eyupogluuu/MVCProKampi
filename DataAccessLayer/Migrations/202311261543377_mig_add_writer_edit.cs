﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_writer_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "writerAbout", c => c.String(maxLength: 150));
            AlterColumn("dbo.Writers", "writerMail", c => c.String(maxLength: 250));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 220));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 20));
            AlterColumn("dbo.Writers", "writerMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "writerAbout");
        }
    }
}
