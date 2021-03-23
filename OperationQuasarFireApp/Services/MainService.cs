using Newtonsoft.Json;
using OperationQuasarFireApp.Contexts;
using OperationQuasarFireApp.CustomExceptions;
using OperationQuasarFireApp.Entities;
using OperationQuasarFireApp.Helpers;
using OperationQuasarFireApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.Services
{
    public class MainService : IMainService
    {
        private readonly AppDbContext _context;
        private readonly ILocationService _locationService;
        private readonly IMessageService _messageService;

        public MainService(AppDbContext context, ILocationService locationService, IMessageService messageService)
        {
            _context = context;
            _locationService = locationService;
            _messageService = messageService;
        }

        public TopSecretResponseModel TopSecret(TopSecretRequestModel request)
        {
            var response = new TopSecretResponseModel();
         
            response.Position = _locationService.GetLocation(request.Satellites);
            response.Message = _messageService.GetMessage(request.Satellites.Select(x => x.Message).ToList());

            return response;
        }

        public SatelliteModel TopSecretSplitPost(string satelliteName, SatelliteModel request)
        {
            Satellite satellite = _context.Satellite.Where(x => x.SatelliteName == satelliteName).FirstOrDefault();

            if (satellite == null)
                throw new SatellitesIsNullException("No se encontro satélite " + satelliteName);

            try
            {
                satellite.Distance = request.Distance;
                satellite.MessageArray = request.Message == null || request.Message.Count() == 0 ? null : string.Join(",", request.Message);
                _context.Satellite.Update(satellite);
                _context.SaveChanges();
            } catch (Exception)
            {
                throw new SatellitesUpdateDataException("Ocurrió un error al actualizar datos, por favor revise los datos.");
            }

            return request;
        }

        public TopSecretResponseModel TopSecretSplit()
        {
            List<SatelliteModel> satellites = getSatellitesFromDB();

            validateRequiredData(satellites);

            return TopSecret(new TopSecretRequestModel() { Satellites = satellites });
        }

        private List<SatelliteModel> getSatellitesFromDB()
        {
            List<SatelliteModel> satellites = _context.Satellite.Select(x => new SatelliteModel()
            {
                Name = x.SatelliteName,
                Distance = x.Distance,
                Message = x.MessageArray == null ? null : x.MessageArray.Split(",", StringSplitOptions.None)
            }).ToList();

            return satellites;
        }

        private void validateRequiredData(List<SatelliteModel> satellites)
        {
            foreach (SatelliteModel satellite in satellites)
            {
                if (satellite.Distance == null)
                    throw new ErrorException("No se encontró la distancia a el satélite " + satellite.Name);
                //if (satellite.Message == null)
                //    throw new ErrorException("No se encontró mensaje de el satélite " + satellite.Name);

            }
        }
    }
}
