using CXManagement.Application.DTOs.CX_Application_Keyword;

namespace CXManagement.Application.DTOs.CX_Keyword
{
    public class KeywordDto
    {
        public int CXKeywordID { get; set; }
        public string CXKeywordName { get; set; }
        public string CXKeywordDescription { get; set; }
        public string CXKeywordDataType { get; set; }
        public string CXKeywordScoringFormula { get; set; }
        public bool CXKeywordIsActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }

        public ICollection<ApplicationKeywordDto>? ApplicationKeywords { get; set; }

        public List<string> AssignedApplicationNames =>
            ApplicationKeywords?
            .Where(ak => ak.Application != null)
            .Select(ak => ak.Application.CXAName)
            .Where(name => !string.IsNullOrEmpty(name))
            .ToList() ?? new();
    }
}
