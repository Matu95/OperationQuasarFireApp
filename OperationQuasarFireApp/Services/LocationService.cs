using OperationQuasarFireApp.CustomExceptions;
using OperationQuasarFireApp.Helpers;
using OperationQuasarFireApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.Services
{
    public class LocationService : ILocationService
    {
        public  PositionModel GetLocation(List<SatelliteModel> satellites)
        {
            if (satellites.Count != 3)
                throw new SatellitesRequiredException("Se deben ingresar las distancias a los tres satélites");

            double distanceToKenobi = Decimal.ToDouble(satellites.Find(x => x.Name == "kenobi").Distance);
            double distanceToSkywalker = Decimal.ToDouble(satellites.Find(x => x.Name == "skywalker").Distance);
            double distanceToSato = Decimal.ToDouble(satellites.Find(x => x.Name == "sato").Distance);

            iBeacon satelliteKenobi = new iBeacon(-500, -200, distanceToKenobi);
            iBeacon satelliteSkywalker = new iBeacon(100, -100, distanceToSkywalker);
            iBeacon satelliteSato = new iBeacon(500, 100, distanceToSato);

            var result = TrilaterationHelper.Trilaterate(satelliteKenobi, satelliteSkywalker, satelliteSato);

            return new PositionModel()
            {
                x = result.X,
                y = result.Y
            };
        }
    }
}
