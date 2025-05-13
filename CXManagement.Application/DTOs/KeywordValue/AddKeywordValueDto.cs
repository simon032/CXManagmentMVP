namespace CXManagement.Application.DTOs.KeywordValue
{
    public class AddKeywordValueDto
    {
        public int CXCustomerID { get; set; }
        public int CXKeywordID { get; set; }
        public string CXKeywordValueValueString { get; set; }
        public int CreateBy { get; set; }
    }
}
