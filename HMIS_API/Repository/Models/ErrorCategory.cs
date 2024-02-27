using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class ErrorCategory
    {
        public int Id { get; set; }
        public string ErrorCode { get; set; }
        public string Remark { get; set; }
    }
}
