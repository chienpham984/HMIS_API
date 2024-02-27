﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class Nature
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public string FlightType { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserName { get; set; }
        public bool? Acvstatus { get; set; }
        public DateTime? Acvtime { get; set; }
    }
}
