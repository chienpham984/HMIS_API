using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class ApiFlight
    {
        public string FlightId { get; set; }
        public string FlightNo { get; set; }
        public DateTime? FlightDate { get; set; }
        public string Route { get; set; }
        public string Status { get; set; }
        public string ArrDep { get; set; }
        public string AcregNo { get; set; }
        public string AcType { get; set; }
        public string FlightType { get; set; }
        public string Acgt { get; set; }
        public string Aegt { get; set; }
        public string Mgha { get; set; }
        public string Base { get; set; }
        public string Sibt { get; set; }
        public string Aibt { get; set; }
        public string Sobt { get; set; }
        public string Asbt { get; set; }
        public int? Ettt { get; set; }
        public string Ardt { get; set; }
        public string Eobt { get; set; }
        public string Aobt { get; set; }
        public string Tobt { get; set; }
    }
}
