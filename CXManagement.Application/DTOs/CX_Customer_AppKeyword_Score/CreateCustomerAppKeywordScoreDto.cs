namespace CXManagement.Application.DTOs.CX_Customer_AppKeyword_Score
{
    public class CreateCustomerAppKeywordScoreDto
    {
        public int? CXCustomerID { get; set; }
        public int? CXASKID { get; set; }
        public double? CXCAKCalculatedScore { get; set; }
        public DateTime? CXCAKCalculatedDate { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
