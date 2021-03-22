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
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("topsecret")]
        public IActionResult TopSecret([FromBody] TopSecretRequestModel request)
        {
            Point2D position1 = new Point2D(-500, -200, 806.23);
            Point2D position2 = new Point2D(100, -100, 282.84);
            Point2D position3 = new Point2D(500, 100, 447.21);

            Point2D userPosition = Trilateration.getTrilateration(position1, position2, position3);

            TopSecretResponseModel response = _mainService.TopSecret(request);

            return Ok(response);
        }

        /// <summary>
        /// 
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
        /// 
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
