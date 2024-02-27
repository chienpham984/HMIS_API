using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class CongViec
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public int? IdNguoiDung { get; set; }
        public string FlightDate { get; set; }
    }
}
