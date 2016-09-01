using CarFuel.Models;
using CarFuel.Services.Bases;
using System;
using System.Linq;
using CarFuel.DataAccess.Bases;

namespace CarFuel.Services {
  public class CarService : ServiceBase<Car>, ICarService {

    private readonly IUserService _userService;

    public CarService(IRepository<Car> baseRepo, 
                      IUserService userService) 
      : base(baseRepo) {
      _userService = userService;
    }

    public override Car Find(params object[] keys) {
      var key1 = (Guid)keys[0];
      return Query(x => x.Id == key1).SingleOrDefault();
    }

    public override IQueryable<Car> All() {
      if (_userService.CurrentUser == null) {
        //return Enumerable.Empty<Car>().AsQueryable();
        throw new Exception();
      }
      return Query(c => c.Owner == _userService.CurrentUser);
    }

    public override Car Add(Car item) {
      if (All().Any(c => c.Name == item.Name)) {
        throw new Exception("This name has been used already.");
      } 

      return base.Add(item);
    }
    
  }
}
