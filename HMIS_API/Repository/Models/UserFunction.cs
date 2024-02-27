namespace HMIS_API.Repository.Models
{
    public class UserFunction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ListView { get; set; }
        public string ListInsert { get; set; }
        public string ListUpdate { get; set; }
    }
}
