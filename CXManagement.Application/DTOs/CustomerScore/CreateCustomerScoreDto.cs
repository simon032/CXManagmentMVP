namespace CXManagement.Application.DTOs.CustomerScore
{
    public class CreateCustomerScoreDto
    {
        public int CXCustomerID { get; set; }
        public int CXKeywordID { get; set; }
        public float CXCustomerScoreCalculatedScore { get; set; }
        public int CreateBy { get; set; }
    }
}
