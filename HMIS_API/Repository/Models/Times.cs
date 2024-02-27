using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMIS_API.Repository.Models
{
    public partial class Times
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int? CreateTimes { get; set; }
        [StringLength(10)]
        public string FlightDate { get; set; }
        [Column("isSent")]
        public bool? IsSent { get; set; }
        [Column("timeSent", TypeName = "datetime")]
        public DateTime? TimeSent { get; set; }
        [Column("timechange")]
        [StringLength(22)]
        public string Timechange { get; set; }
    }
}
