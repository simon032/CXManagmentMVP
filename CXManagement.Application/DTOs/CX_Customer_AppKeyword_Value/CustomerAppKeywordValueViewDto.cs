namespace CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value
{
    public class CustomerAppKeywordValueViewDto
    {
        public int CXCAKVID { get; set; }
        public int? CXCustomerID { get; set; }
        public int? CXASKID { get; set; }
        public string CXCAKVValueString { get; set; }
        public DateTime? CXCAKVAssignedDate { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }

        public int? ApplicationID { get; set; }
        public string? ApplicationName { get; set; }
        public int? KeywordID { get; set; }
        public string? KeywordName { get; set; }
    }
}
