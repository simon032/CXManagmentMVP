namespace CXManagmentMVP.Domain.Entities
{
    public class ApplicationSystem
    {
        public int CXASID { get; set; }
        public string? CXASName { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
