using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class ViewConfigDefault
    {
        public int Id { get; set; }
        public int? IdBoPhan { get; set; }
        public string ListColumn { get; set; }
    }
}
