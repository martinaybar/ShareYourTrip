namespace ShareYourTrip.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        City_Id = c.Int(),
                        Trip_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Trips", t => t.Trip_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Trip_Id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TripName = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TripServices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TripTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.UserPreferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TripServiceTrips",
                c => new
                    {
                        TripService_Id = c.Guid(nullable: false),
                        Trip_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.TripService_Id, t.Trip_Id })
                .ForeignKey("dbo.TripServices", t => t.TripService_Id, cascadeDelete: true)
                .ForeignKey("dbo.Trips", t => t.Trip_Id, cascadeDelete: true)
                .Index(t => t.TripService_Id)
                .Index(t => t.Trip_Id);
            
            CreateTable(
                "dbo.TripTypeTrips",
                c => new
                    {
                        TripType_Id = c.Guid(nullable: false),
                        Trip_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.TripType_Id, t.Trip_Id })
                .ForeignKey("dbo.TripTypes", t => t.TripType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Trips", t => t.Trip_Id, cascadeDelete: true)
                .Index(t => t.TripType_Id)
                .Index(t => t.Trip_Id);
            
            CreateTable(
                "dbo.UserPreferenceUserProfiles",
                c => new
                    {
                        UserPreference_Id = c.Int(nullable: false),
                        UserProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserPreference_Id, t.UserProfile_Id })
                .ForeignKey("dbo.UserPreferences", t => t.UserPreference_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id, cascadeDelete: true)
                .Index(t => t.UserPreference_Id)
                .Index(t => t.UserProfile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Profile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserPreferenceUserProfiles", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserPreferenceUserProfiles", "UserPreference_Id", "dbo.UserPreferences");
            DropForeignKey("dbo.UserProfiles", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.TripTypeTrips", "Trip_Id", "dbo.Trips");
            DropForeignKey("dbo.TripTypeTrips", "TripType_Id", "dbo.TripTypes");
            DropForeignKey("dbo.TripServiceTrips", "Trip_Id", "dbo.Trips");
            DropForeignKey("dbo.TripServiceTrips", "TripService_Id", "dbo.TripServices");
            DropForeignKey("dbo.Destinations", "Trip_Id", "dbo.Trips");
            DropForeignKey("dbo.Destinations", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "State_Id", "dbo.States");
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropIndex("dbo.UserPreferenceUserProfiles", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserPreferenceUserProfiles", new[] { "UserPreference_Id" });
            DropIndex("dbo.TripTypeTrips", new[] { "Trip_Id" });
            DropIndex("dbo.TripTypeTrips", new[] { "TripType_Id" });
            DropIndex("dbo.TripServiceTrips", new[] { "Trip_Id" });
            DropIndex("dbo.TripServiceTrips", new[] { "TripService_Id" });
            DropIndex("dbo.UserProfiles", new[] { "City_Id" });
            DropIndex("dbo.Users", new[] { "Profile_Id" });
            DropIndex("dbo.Trips", new[] { "User_Id" });
            DropIndex("dbo.Destinations", new[] { "Trip_Id" });
            DropIndex("dbo.Destinations", new[] { "City_Id" });
            DropIndex("dbo.States", new[] { "Country_Id" });
            DropIndex("dbo.Cities", new[] { "State_Id" });
            DropTable("dbo.UserPreferenceUserProfiles");
            DropTable("dbo.TripTypeTrips");
            DropTable("dbo.TripServiceTrips");
            DropTable("dbo.UserPreferences");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Users");
            DropTable("dbo.TripTypes");
            DropTable("dbo.TripServices");
            DropTable("dbo.Trips");
            DropTable("dbo.Destinations");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
        }
    }
}
