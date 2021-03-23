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
            if (satellites.Any(x => x.Distance == null || x.Distance == 0))
                throw new ErrorException("Es necesario enviar una distancia válida.");

            double distanceToKenobi = Decimal.ToDouble((Decimal)satellites.Find(x => x.Name == "kenobi").Distance);
            double distanceToSkywalker = Decimal.ToDouble((Decimal)satellites.Find(x => x.Name == "skywalker").Distance);
            double distanceToSato = Decimal.ToDouble((Decimal)satellites.Find(x => x.Name == "sato").Distance);

            TrilaterationModel satelliteKenobi = new TrilaterationModel(-500, -200, distanceToKenobi);
            TrilaterationModel satelliteSkywalker = new TrilaterationModel(100, -100, distanceToSkywalker);
            TrilaterationModel satelliteSato = new TrilaterationModel(500, 100, distanceToSato);

            return getPosition(satelliteKenobi, satelliteSkywalker, satelliteSato);
        } 

        private PositionModel getPosition(TrilaterationModel satelliteKenobi, TrilaterationModel satelliteSkywalker, TrilaterationModel satelliteSato)
        {
            TrilaterationModel result;

            try
            {
                result = Trilateration.getTrilateration(satelliteKenobi, satelliteSkywalker, satelliteSato);
            }
            catch (Exception)
            {
                throw new ErrorException("Ocurrió un error al obtener localización de emisor.");
            }

            return new PositionModel()
            {
                X = Math.Round(result.X, 2),
                Y = Math.Round(result.Y, 2)
            };
        }
    }
}
