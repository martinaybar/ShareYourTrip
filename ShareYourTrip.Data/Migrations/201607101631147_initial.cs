namespace ShareYourTrip.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TripClasifications", "UserAgeRange", c => c.Int(nullable: false));
            DropColumn("dbo.TripClasifications", "UserAgeCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TripClasifications", "UserAgeCategory", c => c.Int(nullable: false));
            DropColumn("dbo.TripClasifications", "UserAgeRange");
        }
    }
}
