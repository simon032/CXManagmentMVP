using CXManagement.Application.DTOs.CX_Application_Keyword;

namespace CXManagement.Application.DTOs.CX_Application
{
    public class ApplicationDto
    {
        public int CXAID { get; set; }
        public string CXAName { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }
        public ICollection<ApplicationKeywordDto>? ApplicationKeywords { get; set; }
    }
}
