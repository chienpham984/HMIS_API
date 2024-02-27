using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMIS_API.Repository.Models
{
    [Table("ETTTDetails")]
    public partial class Etttdetails
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public int? Time { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateModified { get; set; }
        [Column("ACVStatus")]
        public bool? Acvstatus { get; set; }
        [Column("ACVTime", TypeName = "datetime")]
        public DateTime? Acvtime { get; set; }
        public int? No { get; set; }
    }
}
