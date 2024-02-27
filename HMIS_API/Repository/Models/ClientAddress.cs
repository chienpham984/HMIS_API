using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class ClientAddress
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FlightDate { get; set; }
        public int? FlightId { get; set; }
        public string Address { get; set; }
    }
}
