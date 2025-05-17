namespace CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value
{
    public class CreateCustomerAppKeywordValueDto
    {
        public int? CXCustomerID { get; set; }
        public int? CXASKID { get; set; }
        public string CXCAKVValueString { get; set; }
        public DateTime? CXCAKVAssignedDate { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
