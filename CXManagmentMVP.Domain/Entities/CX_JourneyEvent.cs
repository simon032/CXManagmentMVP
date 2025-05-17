using CXManagmentMVP.Domain.Enums;

namespace CXManagmentMVP.Domain.Entities
{
    public class CX_JourneyEvent
    {
        public int CXCJEID { get; set; }
        public int? CXASID { get; set; }
        public string? CXJEKeywordIDs { get; set; }
        public JourneyEventStage? CXJEStage { get; set; }
        public float? CXJEScoreSnapshot { get; set; }
        public DateTime? CXJERequestedDate { get; set; }
        public DateTime? CXJEFromDate { get; set; }
        public DateTime? CXJEToDate { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }

        public CX_Application? Application { get; set; }
    }
}
