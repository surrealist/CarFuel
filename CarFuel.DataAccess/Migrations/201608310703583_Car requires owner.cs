namespace CarFuel.DataAccess.Migrations {
  using System;
  using System.Data.Entity.Migrations;

  public partial class Carrequiresowner : DbMigration {
    public override void Up() {
      DropForeignKey("dbo.Cars", "Owner_UserId", "dbo.Users");
      DropIndex("dbo.Cars", new[] { "Owner_UserId" });


      var zeroId = new Guid();
      Sql($"UPDATE dbo.Cars SET Owner_UserId='{zeroId}' WHERE Owner_UserId IS NULL");

      AlterColumn("dbo.Cars", "Owner_UserId", c => c.Guid(nullable: false));


      CreateIndex("dbo.Cars", "Owner_UserId");
      AddForeignKey("dbo.Cars", "Owner_UserId", "dbo.Users", "UserId", cascadeDelete: true);
    }

    public override void Down() {
      DropForeignKey("dbo.Cars", "Owner_UserId", "dbo.Users");
      DropIndex("dbo.Cars", new[] { "Owner_UserId" });
      AlterColumn("dbo.Cars", "Owner_UserId", c => c.Guid());
      CreateIndex("dbo.Cars", "Owner_UserId");
      AddForeignKey("dbo.Cars", "Owner_UserId", "dbo.Users", "UserId");
    }
  }
}
