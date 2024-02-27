using System;

namespace HMIS_API.Repository.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int DeptId { get; set; }
        public int RolesId { get; set; }
        public string ListStation { get; set; }
        public Boolean UserStatus { get; set; }
    }
}
