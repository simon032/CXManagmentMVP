namespace CXManagement.Application.DTOs.ScoreHistory
{
    public class LogScoreHistoryDto
    {
        public int CXCustomerID { get; set; }
        public int CXKeywordID { get; set; }
        public float CXScoreHistoryScore { get; set; }
        public int CreateBy { get; set; }
    }
}
