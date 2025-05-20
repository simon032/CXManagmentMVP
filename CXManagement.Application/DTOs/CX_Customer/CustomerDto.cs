using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;

namespace CXManagement.Application.DTOs.CX_Customer
{
    public class CustomerDto
    {
        public int CXCustomerID { get; set; }
        public string CXCustomerFullName { get; set; }
        public string CXCustomerEmail { get; set; }
        public string CXCustomerPhone { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }

        public ICollection<CustomerAppKeywordValueDto>? Values { get; set; }
    }
}
