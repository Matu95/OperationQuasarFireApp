using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.Entities
{
    public class Satellite
    {
        [Key]
        public int Id { get; set; }
        public string SatelliteName { get; set; }
        public decimal Distance { get; set; }
        public string MessageArray { get; set; }
    }
}
