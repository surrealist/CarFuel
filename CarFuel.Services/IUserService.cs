using CarFuel.Models;
using CarFuel.Services.Bases;
using System;

namespace CarFuel.Services {
  public interface IUserService : IService<User> {

    User CurrentUser { get; set; } 

  }
}
