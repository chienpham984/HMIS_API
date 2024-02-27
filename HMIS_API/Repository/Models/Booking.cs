using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMIS_API.Repository.Models
{
    public class Booking
    {
        public int id { get; set; }
        public int? FlightId { get; set; }
        public int Pax { get; set; }
        public string MGHA { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
