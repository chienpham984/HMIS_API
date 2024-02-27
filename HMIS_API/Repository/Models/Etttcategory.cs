using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class Etttcategory
    {
        public int Id { get; set; }
        public string Nature { get; set; }
        public string FlightType { get; set; }
        public string Airlines { get; set; }
        public int? Time { get; set; }
        public string NatureOfFlight { get; set; }
    }
}
