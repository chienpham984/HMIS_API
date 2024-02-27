using HMIS_API.Repository.Models;
using System.Collections.Generic;

namespace HMIS_API.Repository.QH
{
    public class MailSystemAPI
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public MailSystem Data { get; set; }
    }
}
