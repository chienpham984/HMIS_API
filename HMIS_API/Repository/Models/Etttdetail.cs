using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class Etttdetail
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public int? Time { get; set; }
        public string UserName { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? Acvstatus { get; set; }
        public DateTime? Acvtime { get; set; }
        public int? No { get; set; }
    }
}
