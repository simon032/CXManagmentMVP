using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.DTOs.CX_Keyword;

namespace CXManagement.Application.DTOs.CX_Application_Keyword
{
    public class ApplicationKeywordDto
    {
        public int CXAKID { get; set; }
        public int? CXASID { get; set; }
        public int? CXKeywordID { get; set; }
        public double? CXAKWeight { get; set; }
        public ApplicationDto? Application { get; set; }
        public KeywordDto? Keyword { get; set; }
    }
}
