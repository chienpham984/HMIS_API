using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class NguoiDung
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public int? IdBoPhan { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Url { get; set; }
    }
}
