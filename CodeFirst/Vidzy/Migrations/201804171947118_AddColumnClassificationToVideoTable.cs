namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Vidzy.Models;

    public partial class AddColumnClassificationToVideoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Classification", c => c.Int(nullable: false));
            Sql("UPDATE Videos SET Classification = " + (int)Classification.Silver);
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "Classification");
        }
    }
}
