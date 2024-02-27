using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMIS_API.Repository.Models
{
    public partial class Messages
    {
        [Key]
        [Column("MessageID")]
        public int MessageId { get; set; }
        [StringLength(50)]
        public string Message { get; set; }
        [StringLength(50)]
        public string EmptyMessage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
    }
}
