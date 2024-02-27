using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMIS_API.Repository.ModelView
{
    public class FlightUpdateModel
    {

        public string FlightNo { get; set; }

        public DateTime FlightDate { get; set; }

        public string Route { get; set; }
  
        public List<FlightDataUpdateModel> FlightData { get; set; }
    }
    public class FlightDataUpdateModel
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string ValueOLD { get; set; }
        public string InputSource { get; set; }
        public DateTime InputTime { get; set; }
    }
}
