namespace CXManagement.Application.DTOs.CX_Keyword
{
    public class CreateKeywordDto
    {
        public string CXKeywordName { get; set; }
        public string CXKeywordDescription { get; set; }
        public string CXKeywordDataType { get; set; }
        public string CXKeywordScoringFormula { get; set; }
        public bool? CXKeywordIsActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
