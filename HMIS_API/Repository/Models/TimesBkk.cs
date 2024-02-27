using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class TimesBkk
    {
        public int Id { get; set; }
        public int? CreateTimes { get; set; }
        public string FlightDate { get; set; }
        public bool? IsSent { get; set; }
        public DateTime? TimeSent { get; set; }
        public string Timechange { get; set; }
    }
}
