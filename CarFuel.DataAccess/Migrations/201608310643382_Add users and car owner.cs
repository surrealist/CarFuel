namespace CarFuel.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addusersandcarowner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false),
                        ConsumptionRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Cars", "Owner_UserId", c => c.Guid());
            CreateIndex("dbo.Cars", "Owner_UserId");
            AddForeignKey("dbo.Cars", "Owner_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Owner_UserId", "dbo.Users");
            DropIndex("dbo.Cars", new[] { "Owner_UserId" });
            DropColumn("dbo.Cars", "Owner_UserId");
            DropTable("dbo.Users");
        }
    }
}
