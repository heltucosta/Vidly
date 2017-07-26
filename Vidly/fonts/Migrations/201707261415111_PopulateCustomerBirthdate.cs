namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate='1990-12-17' WHERE ID=1");
        }
        
        public override void Down()
        {
        }
    }
}
