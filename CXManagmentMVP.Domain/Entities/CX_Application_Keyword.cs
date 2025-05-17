namespace CXManagmentMVP.Domain.Entities
{
    public class CX_Application_Keyword
    {
        public int CXAKID { get; set; }
        public int? CXASID { get; set; }
        public int? CXKeywordID { get; set; }
        public float? CXAKWeight { get; set; }

        public CX_Application? Application { get; set; }
        public CX_Keyword? Keyword { get; set; }
        public ICollection<CX_Customer_AppKeyword_Value>? Values { get; set; }
        public ICollection<CX_Customer_AppKeyword_Score>? Scores { get; set; }
    }
}
