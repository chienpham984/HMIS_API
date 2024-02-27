using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HMIS_API.Repository.Models
{

    [Table("SMIS1")]
    public partial class SMIS1
    {
        [Key]
        public Int64 id { get; set; }
        public string FlightNo { get; set; }
        public string FlightDate { get; set; }
        public string ArrTime { get; set; }
        public string DepTime { get; set; }
        public string RouteFlight { get; set; }
        public string ArrDep { get; set; }
        public string AcregNo { get; set; }
        public string AcType { get; set; }
        public string Nature { get; set; }
        public string Note { get; set; }
        public string Position { get; set; }
        public string Gate { get; set; }
    }
}

