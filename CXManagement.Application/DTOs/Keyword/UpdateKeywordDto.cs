namespace CXManagement.Application.DTOs.Keyword
{
    public class UpdateKeywordDto
    {
        public int CXKeywordID { get; set; }
        public string? CXKeywordName { get; set; }
        public string? CXKeywordDescription { get; set; }
        public string? CXKeywordDataType { get; set; }
        public string? CXKeywordScoringFormula { get; set; }
        public bool? CXKeywordIsActive { get; set; }
        public int? ModifyBy { get; set; }
    }
}
