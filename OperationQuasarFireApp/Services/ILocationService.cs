using OperationQuasarFireApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.Services
{
    public interface ILocationService
    {
        PositionModel GetLocation(List<SatelliteModel> satellites);
    }
}
