using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class ErrorDetail
    {
        public int Id { get; set; }
        public int? ErrorCodeId { get; set; }
        public int? FlightId { get; set; }
        public DateTime? Datemodified { get; set; }
        public bool? Status { get; set; }
        public string Remark { get; set; }
    }
}
