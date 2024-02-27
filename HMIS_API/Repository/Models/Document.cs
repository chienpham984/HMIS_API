namespace HMIS_API.Repository.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public int FlightID { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentName { get; set; }
        public string DateModified { get; set; }
        public string DocumentSize { get; set; }
        public string FullPath { get; set; }
    }
}
