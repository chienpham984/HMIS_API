using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HMIS_API.Repository.Models
{

        [Table("API_Flight")]
        public partial class API_Flight
        {
            [Key]
            public string FlightId { get; set; }
            public string FlightNo { get; set; }
            public DateTime FlightDate { get; set; }
            public string Route { get; set; }
            public string Status { get; set; }
            public string ArrDep { get; set; }
            public string AcregNo { get; set; }
            public string AcType { get; set; }
            public string FlightType { get; set; }
            public string ACGT { get; set; }
            public string AEGT { get; set; }
            public string MGHA { get; set; }
            public string Base { get; set; }
            public string SIBT { get; set; }
            public string AIBT { get; set; }
            public string SOBT { get; set; }
            public string ASBT { get; set; }
            public int ETTT { get; set; }
            public string ARDT { get; set; }
            public string EOBT { get; set; }
            public string AOBT { get; set; }
            public string TOBT { get; set; }
        }
    }

