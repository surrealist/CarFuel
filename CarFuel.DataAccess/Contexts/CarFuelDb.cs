using CarFuel.Models;
using System.Data.Entity;

namespace CarFuel.DataAccess.Contexts {

  public class CarFuelDb : DbContext {

    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; } // +

  }

} 