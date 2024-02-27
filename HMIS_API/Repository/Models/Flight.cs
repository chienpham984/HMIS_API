using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class Flight
    {
        public int? FlightId { get; set; }
        public string FlightNo { get; set; }
        public int? LinkFlight { get; set; }
        public string ArrDep { get; set; }
        public string FlightDate { get; set; }
        public string FlightTime { get; set; }
        public string FSibt { get; set; }
        public string FEibt { get; set; }
        public string FAibt { get; set; }
        public string FSobt { get; set; }
        public string FEobt { get; set; }
        public string FAobt { get; set; }
        public string FAcgt { get; set; }
        public string FArdt { get; set; }
        public string FAsbt { get; set; }
        public int? Ettt { get; set; }
        public string RouteFlight { get; set; }
        public string Nature { get; set; }
        public string Remark { get; set; }
        public int Id { get; set; }
        public string Status { get; set; }
        public string Apark { get; set; }
        public string Dpark { get; set; }
        public string FBelt { get; set; }
        public string FEldt { get; set; }
        public string FAldt { get; set; }
        public string FTobt { get; set; }
        public string FTsat { get; set; }
        public string FTtot { get; set; }
        public DateTime? FlightDateTime { get; set; }
        public string FATOT { get; set; }
        public string Dgate { get; set; }
        public string FAEGT { get; set; }
        public string MVT { get; set; }
        public string CLSD { get; set; }
    }
}
