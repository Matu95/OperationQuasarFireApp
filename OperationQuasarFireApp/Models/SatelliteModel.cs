using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.Models
{
    public class SatelliteModel
    {
        public string Name { get; set; }
        public decimal? Distance { get; set; }
        public string[] Message { get; set; } = null;
    }
}
