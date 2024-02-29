using System;
using System.Security.Permissions;

namespace HMIS_API.Repository.QH
{
    public class UserItem
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int RolesId { get; set; }
        public string RoleName { get; set; }
        public DateTime DOB { get; set; }
        public string ListArea { get; set; }
        public string ListView { get; set; }
        public string ListInsert { get; set; }
        public string ListUpdate { get; set; }
    }
}
