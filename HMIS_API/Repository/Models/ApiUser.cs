using System;
using System.Collections.Generic;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class ApiUser
    {
        public string UserName { get; set; }
        public string Pasword { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
    }
}
