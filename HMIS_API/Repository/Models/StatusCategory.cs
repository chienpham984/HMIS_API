using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class StatusCategory
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Remark { get; set; }
    }
}
