using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class ViewConfigDetail
    {
        public int Id { get; set; }
        public int? IdBoPhan { get; set; }
        public int? IdNguoiDung { get; set; }
        public string ListColumn { get; set; }
    }
}
