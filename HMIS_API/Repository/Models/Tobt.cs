using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class Tobt
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public int? FlightId { get; set; }
        public string UserName { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? Acvstatus { get; set; }
        public DateTime? Acvtime { get; set; }
        public int? No { get; set; }
        public string Mgha { get; set; }
    }
}
