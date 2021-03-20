using Microsoft.AspNetCore.Mvc;
using OperationQuasarFireApp.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OperationQuasarFireApp.Controllers
{
    [Route("main")]
    public class MainController : ControllerBase
    {
        [HttpPost("topsecret")]
        public IActionResult TopSecret([FromBody] TopSecretRequestModel request)
        {
            var response = new TopSecretResponseModel();
            var position = new PositionModel()
            {
                x = float.Parse("-100.0", CultureInfo.InvariantCulture.NumberFormat),
                y = float.Parse("75.5", CultureInfo.InvariantCulture.NumberFormat)
            };

            response.position = position;
            response.message = GetMessage(request.satellites.Select(x => x.message).ToList());

            return Ok(response);
        }

        [HttpGet("topsecret_split/{satelliteName}")]
        public IActionResult TopSecretSplitBySatelliteName([FromQuery] string satelliteName)
        {
            return Ok(new TopSecretSplitResponseModel());
        }

        [HttpPost("topsecret_split")]
        public IActionResult TopSecretSplit([FromBody] SatellitesModel satellites)
        {
            return Ok(new TopSecretSplitResponseModel());
        }

        private string GetLocation(float distanceA, float distanceB, float distanceC)
        {
            return null;
        }

        private string GetMessage(List<string[]> messages)
        {

            string[] result = messages.First();

            foreach (string[] message in messages)
                for (int i = 0; i < message.Length; i++)
                    if(!string.IsNullOrEmpty(message[i]))
                        result[i] = message[i];

            return string.Join(" ", result);
        }
    }
}
