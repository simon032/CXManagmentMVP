namespace CXManagmentMVP.Domain.Entities
{
    public class KeywordValue
    {
        public int CXKeywordValueID { get; set; }
        public int? CXCustomerID { get; set; }
        public int? CXKeywordID { get; set; }
        public string? CXKeywordValueValueString { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
