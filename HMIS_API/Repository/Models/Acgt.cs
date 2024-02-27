using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class Acgt
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public string Time { get; set; }
        public string UserName { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? Acvstatus { get; set; }
        public DateTime? Acvtime { get; set; }
        public string FlightDate { get; set; }
        public string Mgha { get; set; }
        public string Remark { get; set; }
    }
}
