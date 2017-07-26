namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreFKToMovie : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreID");
            RenameIndex(table: "dbo.Movies", name: "IX_Genre_Id", newName: "IX_GenreID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenreID", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Movies", name: "GenreID", newName: "Genre_Id");
        }
    }
}
