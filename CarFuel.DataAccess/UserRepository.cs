using CarFuel.DataAccess.Bases;
using CarFuel.Models; 
using System.Data.Entity;

namespace CarFuel.DataAccess {
  public class UserRepository : RepositoryBase<User> {
    public UserRepository(DbContext context) : base(context) {
    }
  }
}
