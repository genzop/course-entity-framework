namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Courses", "Title", "Name");

            //AddColumn("dbo.Courses", "Name", c => c.String(nullable:  false));
            //Sql("UPDATE Courses SET Name = Title");
            //DropColumn("dbo.Courses", "Title");           
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Courses", "Name", "Title");

            //AddColumn("dbo.Courses", "Title", c => c.String(nullable: false));
            //Sql("UPDATE Courses SET Title = Name");
            //DropColumn("dbo.Courses", "Name");            
        }
    }
}
