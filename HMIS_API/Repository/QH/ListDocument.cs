namespace HMIS_API.Repository.QH
{
    public class ListDocument
    {
        public int DocumentId { get; set; }
        public int FlightID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentTypeName { get; set; }
        public string DateModified { get; set; }
        public string FullPath { get; set; }


    }
}
