namespace MovieCruiser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        C_id = c.Int(nullable: false, identity: true),
                        Customerid = c.Int(nullable: false),
                        CustomerName = c.String(maxLength: 255),
                        DateofBirth = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.C_id);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        F_id = c.Int(nullable: false, identity: true),
                        M_Id = c.Int(nullable: false),
                        M_Title = c.String(),
                        M_Boxoffice = c.String(),
                        Genre = c.Int(nullable: false),
                        Customerid_C_id = c.Int(),
                    })
                .PrimaryKey(t => t.F_id)
                .ForeignKey("dbo.Customers", t => t.Customerid_C_id)
                .Index(t => t.Customerid_C_id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        M_Id = c.Int(nullable: false, identity: true),
                        M_Title = c.String(nullable: false, maxLength: 50),
                        M_BoxOffice = c.String(),
                        M_Active = c.String(),
                        M_DateOfLaunch = c.DateTime(nullable: false),
                        Genre = c.Int(nullable: false),
                        Customerid_C_id = c.Int(),
                    })
                .PrimaryKey(t => t.M_Id)
                .ForeignKey("dbo.Customers", t => t.Customerid_C_id)
                .Index(t => t.Customerid_C_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Customerid_C_id", "dbo.Customers");
            DropForeignKey("dbo.Favorites", "Customerid_C_id", "dbo.Customers");
            DropIndex("dbo.Movies", new[] { "Customerid_C_id" });
            DropIndex("dbo.Favorites", new[] { "Customerid_C_id" });
            DropTable("dbo.Movies");
            DropTable("dbo.Favorites");
            DropTable("dbo.Customers");
        }
    }
}
