namespace CXManagement.Application.DTOs.CX_JourneyEvent
{
    public class CreateJourneyEventDto
    {
        public int? CXASID { get; set; }
        public string CXJEKeywordIDs { get; set; }
        public string CXJEStage { get; set; }
        public double? CXJEScoreSnapshot { get; set; }
        public DateTime? CXJERequestedDate { get; set; }
        public DateTime? CXJEFromDate { get; set; }
        public DateTime? CXJEToDate { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreateBy { get; set; }
    }
}
