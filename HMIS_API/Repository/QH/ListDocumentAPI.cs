using HMIS_API.Repository.Models;
using System.Collections.Generic;

namespace HMIS_API.Repository.QH
{
    public class ListDocumentAPI
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<ListDocument> Data { get; set; }
    }
}
