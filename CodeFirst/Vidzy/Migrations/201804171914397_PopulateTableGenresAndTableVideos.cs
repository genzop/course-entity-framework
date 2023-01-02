namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTableGenresAndTableVideos : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Drama')");

            Sql("INSERT INTO Videos (Name, ReleaseDate) VALUES ('The Dark Knight', '2008-07-17')");
            Sql("INSERT INTO Videos (Name, ReleaseDate) VALUES ('Schindlers List', '1994-02-24')");

            Sql("INSERT INTO VideoGenres (Video_Id, Genre_Id) VALUES (1, 1)");
            Sql("INSERT INTO VideoGenres (Video_Id, Genre_Id) VALUES (2, 2)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM VideoGenres WHERE Video_Id = 1");
            Sql("DELETE FROM VideoGenres WHERE Video_Id = 2");

            Sql("DELETE FROM Videos WHERE Name = 'The Dark Knight'");
            Sql("DELETE FROM Videos WHERE Name = 'Schindlers List'");

            Sql("DELETE FROM Genres WHERE Name = 'Action'");
            Sql("DELETE FROM Genres WHERE Name = 'Drama'");
        }
    }
}
