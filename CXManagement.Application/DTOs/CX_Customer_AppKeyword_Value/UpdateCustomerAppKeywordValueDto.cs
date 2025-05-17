namespace CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value
{
    public class UpdateCustomerAppKeywordValueDto
    {
        public int CXCAKVID { get; set; }
        public int? CXCustomerID { get; set; }
        public int? CXASKID { get; set; }
        public string CXCAKVValueString { get; set; }
        public DateTime? CXCAKVAssignedDate { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? ModifyBy { get; set; }
    }
}
