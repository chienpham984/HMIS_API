using HMIS_API.Repository.Models;
using System.Collections.Generic;

namespace HMIS_API.Repository.QH
{
    public class UserAPI
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<User> Data { get; set; }
    }
}
