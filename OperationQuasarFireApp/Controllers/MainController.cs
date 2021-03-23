using Microsoft.AspNetCore.Mvc;
using OperationQuasarFireApp.Contexts;
using OperationQuasarFireApp.Helpers;
using OperationQuasarFireApp.Models;
using OperationQuasarFireApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OperationQuasarFireApp.Controllers
{
    [Route("/")]
    public class MainController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMainService _mainService;

        public MainController(AppDbContext context,IMainService mainService)
        {
            this.context = context;
            _mainService = mainService;
        }

        /// <summary>
        /// Devuelve la posicion y mensaje a partir de la distancia y mensajes recibidos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("topsecret")]
        public IActionResult TopSecret([FromBody] TopSecretRequestModel request)
        {
            TopSecretResponseModel response = _mainService.TopSecret(request);

            return Ok(response);
        }

        /// <summary>
        /// Actualiza la posicion y mensaje que recibe un satelite en particular
        /// </summary>
        /// <param name="satelliteName"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("topsecret_split/{satelliteName}")]
        public IActionResult TopSecretSplitBySatelliteName([FromQuery] string satelliteName, [FromBody] SatelliteModel request)
        {
            SatelliteModel satellite = _mainService.TopSecretSplitPost(satelliteName, request); 

            return Ok(satellite);
        }

        /// <summary>
        /// Devuelve la pocicion y mensaje a partir de los datos enviados por el método /topsecret_split/{satelliteName}
        /// </summary>
        /// <returns></returns>
        [HttpGet("topsecret_split")]
        public IActionResult TopSecretSplit()
        {
            TopSecretResponseModel response = _mainService.TopSecretSplit();

            return Ok(response);
        }

    }

}
