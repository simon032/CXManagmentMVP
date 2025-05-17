namespace CXManagement.Application.DTOs.CX_Application
{
    public class UpdateApplicationDto
    {
        public int CXAID { get; set; } // ID required for update
        public string CXAName { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? ModifyBy { get; set; }
    }
}
