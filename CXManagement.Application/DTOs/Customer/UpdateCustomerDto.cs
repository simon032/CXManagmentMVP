namespace CXManagement.Application.DTOs.Customer
{
    public class UpdateCustomerDto
    {
        public int CXCustomerID { get; set; }
        public string? CXCustomerFullName { get; set; }
        public string? CXCustomerEmail { get; set; }
        public string? CXCustomerPhone { get; set; }
        public int? CXCustomerExternalCustomerId { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }

    }
}
