namespace ShareYourTrip.Identity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialfirst : DbMigration
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
                        Continent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Continents", t => t.Continent_Id)
                .Index(t => t.Continent_Id);
            
            CreateTable(
                "dbo.Continents",
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
                        Id = c.Int(nullable: false, identity: true),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        DeltaDays = c.Int(nullable: false),
                        City_Id = c.Int(),
                        Trip_Id = c.Int(),
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
                        Id = c.Int(nullable: false, identity: true),
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
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TripTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        UserProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
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
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.TripClasifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserPreferences = c.String(),
                        Genre = c.Int(nullable: false),
                        UserAgeRange = c.Int(nullable: false),
                        TripYearQuarter = c.Int(nullable: false),
                        Destinations = c.String(),
                        TripServicesToShare = c.String(),
                        TripTypes = c.String(),
                        CityFrom_Id = c.Int(),
                        ContinentTo_Id = c.Int(),
                        Trip_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityFrom_Id)
                .ForeignKey("dbo.Continents", t => t.ContinentTo_Id)
                .ForeignKey("dbo.Trips", t => t.Trip_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.CityFrom_Id)
                .Index(t => t.ContinentTo_Id)
                .Index(t => t.Trip_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TripServiceTrips",
                c => new
                    {
                        TripService_Id = c.Int(nullable: false),
                        Trip_Id = c.Int(nullable: false),
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
                        TripType_Id = c.Int(nullable: false),
                        Trip_Id = c.Int(nullable: false),
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
            DropForeignKey("dbo.TripClasifications", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TripClasifications", "Trip_Id", "dbo.Trips");
            DropForeignKey("dbo.TripClasifications", "ContinentTo_Id", "dbo.Continents");
            DropForeignKey("dbo.TripClasifications", "CityFrom_Id", "dbo.Cities");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Trips", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserPreferenceUserProfiles", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserPreferenceUserProfiles", "UserPreference_Id", "dbo.UserPreferences");
            DropForeignKey("dbo.UserProfiles", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.TripTypeTrips", "Trip_Id", "dbo.Trips");
            DropForeignKey("dbo.TripTypeTrips", "TripType_Id", "dbo.TripTypes");
            DropForeignKey("dbo.TripServiceTrips", "Trip_Id", "dbo.Trips");
            DropForeignKey("dbo.TripServiceTrips", "TripService_Id", "dbo.TripServices");
            DropForeignKey("dbo.Destinations", "Trip_Id", "dbo.Trips");
            DropForeignKey("dbo.Destinations", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "State_Id", "dbo.States");
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Countries", "Continent_Id", "dbo.Continents");
            DropIndex("dbo.UserPreferenceUserProfiles", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserPreferenceUserProfiles", new[] { "UserPreference_Id" });
            DropIndex("dbo.TripTypeTrips", new[] { "Trip_Id" });
            DropIndex("dbo.TripTypeTrips", new[] { "TripType_Id" });
            DropIndex("dbo.TripServiceTrips", new[] { "Trip_Id" });
            DropIndex("dbo.TripServiceTrips", new[] { "TripService_Id" });
            DropIndex("dbo.TripClasifications", new[] { "User_Id" });
            DropIndex("dbo.TripClasifications", new[] { "Trip_Id" });
            DropIndex("dbo.TripClasifications", new[] { "ContinentTo_Id" });
            DropIndex("dbo.TripClasifications", new[] { "CityFrom_Id" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UserProfiles", new[] { "City_Id" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "UserProfile_Id" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Trips", new[] { "User_Id" });
            DropIndex("dbo.Destinations", new[] { "Trip_Id" });
            DropIndex("dbo.Destinations", new[] { "City_Id" });
            DropIndex("dbo.Countries", new[] { "Continent_Id" });
            DropIndex("dbo.States", new[] { "Country_Id" });
            DropIndex("dbo.Cities", new[] { "State_Id" });
            DropTable("dbo.UserPreferenceUserProfiles");
            DropTable("dbo.TripTypeTrips");
            DropTable("dbo.TripServiceTrips");
            DropTable("dbo.TripClasifications");
            DropTable("dbo.Roles");
            DropTable("dbo.UserPreferences");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.TripTypes");
            DropTable("dbo.TripServices");
            DropTable("dbo.Trips");
            DropTable("dbo.Destinations");
            DropTable("dbo.Continents");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
        }
    }
}
