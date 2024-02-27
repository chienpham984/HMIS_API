using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class Position
    {
        public int Id { get; set; }
        public string Apark { get; set; }
        public DateTime? TimeReceive { get; set; }
        public int? FlightId { get; set; }
        public string Mgha { get; set; }
    }
}
