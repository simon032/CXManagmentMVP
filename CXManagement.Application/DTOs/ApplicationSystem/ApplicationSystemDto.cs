namespace CXManagement.Application.DTOs.ApplicationSystem
{
    public class ApplicationSystemDto
    {
        public int CXASID { get; set; }
        public string? CXASName { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
