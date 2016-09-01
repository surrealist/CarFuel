using CarFuel.DataAccess.Bases;
using CarFuel.Models; 
using System.Data.Entity;

namespace CarFuel.DataAccess {
  public class CarRepository : RepositoryBase<Car> {
    public CarRepository(DbContext context) 
      : base(context) {
      //
    }
  }
}
