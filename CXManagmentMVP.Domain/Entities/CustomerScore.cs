namespace CXManagmentMVP.Domain.Entities
{
    public class CustomerScore
    {
        public int CXCustomerScoreID { get; set; }
        public int? CXCustomerID { get; set; }
        public int? CXKeywordID { get; set; }
        public float? CXCustomerScoreCalculatedScore { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
