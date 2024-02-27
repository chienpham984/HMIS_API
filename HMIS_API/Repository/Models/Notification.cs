using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Mgha { get; set; }
        public DateTime? DateModified { get; set; }
        public string FieldName { get; set; }
    }
}
