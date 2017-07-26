namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMOvies : DbMigration
    {
        public override void Up()
        {
            string now = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id, Name, GenreID, ReleaseDate, DateAdded, NumberInStock) VALUES (1, 'Hangover', 1, 2009-08-21, " + now + ", 5)");
            Sql("INSERT INTO Movies (Id, Name, GenreID, ReleaseDate, DateAdded, NumberInStock) VALUES (2, 'Die Hard', 3, 1988-12-22, " + now + ", 5)");
            Sql("INSERT INTO Movies (Id, Name, GenreID, ReleaseDate, DateAdded, NumberInStock) VALUES (3, 'The Terminator', 3, 1985-03-25, " + now + ", 5)");
            Sql("INSERT INTO Movies (Id, Name, GenreID, ReleaseDate, DateAdded, NumberInStock) VALUES (4, 'Toy Story', 2, 1995-12-22, " + now + ", 5)");
            Sql("INSERT INTO Movies (Id, Name, GenreID, ReleaseDate, DateAdded, NumberInStock) VALUES (5, 'Titanic', 4, 1998-01-16, " +  now + ", 5)");
            Sql("SET IDENTITY_INSERT Movies OFF");
        }
        
        public override void Down()
        {
        }
    }
}
