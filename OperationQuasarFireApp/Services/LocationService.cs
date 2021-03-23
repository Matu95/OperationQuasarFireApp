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

            TrilaterationModel satelliteKenobi = GetTrilaterationModel("kenobi", - 500, -200, satellites);
            TrilaterationModel satelliteSkywalker = GetTrilaterationModel("skywalker", 100, -100, satellites);
            TrilaterationModel satelliteSato = GetTrilaterationModel("sato", 500, 100, satellites);

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

        private TrilaterationModel GetTrilaterationModel(string satelliteName, double x, double y, List<SatelliteModel> satellites)
        {
            TrilaterationModel satelliteKenobi = new TrilaterationModel(0,0,0);

            var satellite = satellites.Find(x => x.Name == satelliteName);

            if (satellite == null)
                throw new ErrorException("No se encontró el satélites, los satélites validos son (kenobi, skywalker, sato)");

            try
            {
                satelliteKenobi = new TrilaterationModel(x, y, Decimal.ToDouble((Decimal)satellite.Distance));
            }
            catch (Exception)
            {
                throw new ErrorException("Ocurrió un error, por favor revise los datos enviados.");
            }

            return satelliteKenobi;
        }
    }
}
