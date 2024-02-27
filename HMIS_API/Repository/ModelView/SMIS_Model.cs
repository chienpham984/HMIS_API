using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMIS_API.Repository.ModelView
{
    public class FlightModel
    {

        public string FlightNo { get; set; }

        public DateTime FlightDate { get; set; }

        public string Route { get; set; }
  
        public List<FlightItemModel> FlightData { get; set; }
    }
    public class FlightItemModel
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }
}
