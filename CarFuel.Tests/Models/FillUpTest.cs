using CarFuel.Models;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarFuel.Tests.Models {
  public class FillUpTest {

    public class KmLProperty { // inner or nested class

      [Fact]
      public void NewFillUpDontHasKmL() {
        // arrange
        var f1 = new FillUp();

        // act
        double? kml = f1.KmL;

        // a 
        Assert.Null(kml);
      }


      [Theory]
      [InlineData(1000, 40.0, 2000, 50.0, 20.0)]
      [InlineData(2000, 50.0, 2500, 20.0, 25.0)]
      public void TwoFillUpsCanCalculateKmL(int odo1, double liters1,
                                            int odo2, double liters2,
                                            double expectedKmL) {
        var f1 = new FillUp(odo1, liters1);
        var f2 = new FillUp(odo2, liters2);
        f1.NextFillUp = f2;

        var kml1 = f1.KmL;
        var kml2 = f2.KmL;

        Assert.Equal(expectedKmL, kml1);
        Assert.Null(kml2);
      }

      [Fact]
      public void OdometerMustGreaterThanThePreviousFillUp() {
        var f1 = new FillUp(50000, 50.0);
        var f2 = new FillUp(49000, 60.0); // ** invalid odo **
        f1.NextFillUp = f2;

        var ex = Assert.Throws<Exception>(() => {

          var kml = f1.KmL;

        });

        ex.Message.ShouldEqual("Odometer should be greater than the previous one.");
      }
       
    }


  }
}
