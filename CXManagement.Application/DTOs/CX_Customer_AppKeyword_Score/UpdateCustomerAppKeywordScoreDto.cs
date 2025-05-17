namespace CXManagement.Application.DTOs.CX_Customer_AppKeyword_Score
{
    public class UpdateCustomerAppKeywordScoreDto
    {
        public int CXCAKScoreID { get; set; }
        public int? CXCustomerID { get; set; }
        public int? CXASKID { get; set; }
        public double? CXCAKCalculatedScore { get; set; }
        public DateTime? CXCAKCalculatedDate { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? ModifyBy { get; set; }
    }
}
