namespace CXManagement.Application.DTOs.CX_Customer
{
    public class CreateCustomerDto
    {
        public string CXCustomerFullName { get; set; }
        public string CXCustomerEmail { get; set; }
        public string CXCustomerPhone { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
