namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='PayAsYouGo' WHERE ID=1");
            Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE ID=2");
            Sql("UPDATE MembershipTypes SET Name='Quaterly' WHERE ID=3");
            Sql("UPDATE MembershipTypes SET Name='Annual' WHERE ID=4");
        }
        
        public override void Down()
        {
        }
    }
}
