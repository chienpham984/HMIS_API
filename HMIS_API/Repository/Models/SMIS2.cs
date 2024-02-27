using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HMIS_API.Repository.Models
{

    [Table("SMIS2")]
    public partial class SMIS2
    {
        [Key]
        public Int64 id { get; set; }
        public string FlightDate { get; set; }
        public string FlightNo { get; set; }
        public string LinkFlightNo { get; set; }
        public string ArrDep { get; set; }
        public string AcregNo { get; set; }
        public string AcType { get; set; }

        public string FlightTime { get; set; }
        public string RouteFlight { get; set; }
    

        public string Nature { get; set; }
        public string POSITION { get; set; }
        public string GATE { get; set; }
        public int ADL { get; set; }
        public int CHD { get; set; }
        public int INF { get; set; }
        public int BAG_Pcs { get; set; }
        public int BAG_weight { get; set; }
        public int CARGO_Pcs { get; set; }
        public int Cargo_Weight { get; set; }
        public int COM_MAIL { get; set; }
    }
}

