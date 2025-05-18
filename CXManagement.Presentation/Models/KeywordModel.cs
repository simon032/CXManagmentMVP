namespace CXManagement.Presentation.Models
{
    public class KeywordModel
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

        public int? CXAID { get; set; }
        public double? CXAKWeight { get; set; }
    }
}
