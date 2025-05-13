namespace CXManagmentMVP.Domain.Entities
{
    public class ScoreHistory
    {
        public int CXScoreHistoryID { get; set; }
        public int? CXCustomerID { get; set; }
        public int? CXKeywordID { get; set; }
        public float? CXScoreHistoryScore { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
