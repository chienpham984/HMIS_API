using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMIS_API.Repository.Models
{
    public class DPOS
    {
        public int Id { get; set; }
        public string Dposition { get; set; }
        public DateTime? TimeReceive { get; set; }
        public int? FlightId { get; set; }
        public string Mgha { get; set; }
    }
}
