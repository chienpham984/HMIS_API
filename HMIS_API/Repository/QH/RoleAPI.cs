using HMIS_API.Repository.Models;
using System.Collections.Generic;

namespace HMIS_API.Repository.QH
{
    public class RoleAPI
    {

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Role> Data { get; set; }
    }
}
