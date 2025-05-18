namespace CXManagement.Application.DTOs.CX_Keyword
{
    public class UpdateKeywordDto
    {
        public int CXKeywordID { get; set; }
        public string CXKeywordName { get; set; }
        public string CXKeywordDescription { get; set; }
        public string CXKeywordDataType { get; set; }
        public string CXKeywordScoringFormula { get; set; }
        public bool? CXKeywordIsActive { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? ModifyBy { get; set; }

    }
}
