using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class Std
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public string FlightDate { get; set; }
        public string Time { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
