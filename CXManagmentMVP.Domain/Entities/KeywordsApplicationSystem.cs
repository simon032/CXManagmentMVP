namespace CXManagmentMVP.Domain.Entities
{
    public class KeywordsApplicationSystem
    {
        public int CXKASID { get; set; }
        public int? CXASID { get; set; }
        public int? CXKeywordID { get; set; }
        public float? CXKASWeight { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
