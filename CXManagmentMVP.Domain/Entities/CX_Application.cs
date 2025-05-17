namespace CXManagmentMVP.Domain.Entities
{
    public class CX_Application
    {
        public int CXAID { get; set; }
        public string? CXAName { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }

        public ICollection<CX_Application_Keyword>? ApplicationKeywords { get; set; }
        public ICollection<CX_JourneyEvent>? JourneyEvents { get; set; }
    }
}
