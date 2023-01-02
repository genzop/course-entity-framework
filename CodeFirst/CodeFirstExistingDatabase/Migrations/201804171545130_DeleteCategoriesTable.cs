namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoriesTable : DbMigration
    {
        public override void Up()
        {
            //Creamos la tabla _Categories que nos servira como historial
            CreateTable(
                "dbo._Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            //Copia la informacion de la tabla Categories a la tabla _Categories
            Sql("INSERT INTO _Categories (Name) SELECT Name FROM Categories");

            //Elimina la tabla Categories
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            //Copia la informacion de la tabla _Categories a la tabla Categories
            Sql("INSERT INTO Categories (Name) SELECT Name FROM _Categories");

            //Elimina la tabla _Categories
            DropTable("dbo._Categories");

        }
    }
}
