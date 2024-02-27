using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace HMIS_API.Repository.Models
{
    public class FlightUpdate
    {
        public int FlightID { get; set; }
        public string FlightNo { get; set; }
        public int LinkFlight { get; set; }
        public string ArrDep { get; set; }
        public string FlightDate { get; set; }
        public string FlightTime { get; set; }
        public string ArrTime { get; set; }
        public string DepTime { get; set; }
        public string RouteFlight { get; set; }
        public string AcRegNo { get; set; }
        public string AcType { get; set; }
        public string Nature { get; set; }
        public string Position { get; set; }
        public string StatusFlight { get; set; }
        public string Gate { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime FlightDateTime { get; set; }


    }
}
