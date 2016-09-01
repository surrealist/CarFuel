namespace CarFuel.DataAccess.Migrations {
  using Models;
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<CarFuel.DataAccess.Contexts.CarFuelDb> {
    public Configuration() {
      AutomaticMigrationsEnabled = false;
      ContextKey = "CarFuel.DataAccess.Contexts.CarFuelDb";
    }

    protected override void Seed(CarFuel.DataAccess.Contexts.CarFuelDb context) {
      var zeroId = new Guid();

      context.Users.AddOrUpdate(
        u => u.UserId,
        new User { UserId = zeroId, DisplayName = "Default User" }
        );
       
    }
  }
}
