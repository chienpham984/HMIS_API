using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string Message1 { get; set; }
        public string EmptyMessage { get; set; }
        public DateTime? Date { get; set; }
    }
}
