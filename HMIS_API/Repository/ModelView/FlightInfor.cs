using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMIS_API.Repository.ModelView
{
    public class FlightInfor
    {
        public int FlightId { get; set; }
        public string flightNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime flightDate { get; set; }
        public string Route { get; set; }
        public List<flightData> FlightData { get; set; }
    }

    public class flightData {
        public string fieldName { get; set; }
        public string fieldValue { get; set; }
    }
}
