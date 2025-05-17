namespace CXManagmentMVP.Domain.Entities
{
    public class CX_Keyword
    {
        public int CXKeywordID { get; set; }
        public string? CXKeywordName { get; set; }
        public string? CXKeywordDescription { get; set; }
        public string? CXKeywordDataType { get; set; }
        public string? CXKeywordScoringFormula { get; set; }
        public bool? CXKeywordIsActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }

        public ICollection<CX_Application_Keyword>? ApplicationKeywords { get; set; }
    }
}
