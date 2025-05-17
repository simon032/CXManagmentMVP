namespace CXManagmentMVP.Domain.Entities
{
    public class CX_Customer
    {
        public int CXCustomerID { get; set; }
        public string? CXCustomerFullName { get; set; }
        public string? CXCustomerEmail { get; set; }
        public string? CXCustomerPhone { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }

        public ICollection<CX_Customer_AppKeyword_Score>? Scores { get; set; }
        public ICollection<CX_Customer_AppKeyword_Value>? Values { get; set; }
    }
}
