namespace CXManagement.Application.DTOs.CustomerJourney
{
    public class CreateCustomerJourneyDto
    {
        public int CXCustomerID { get; set; }
        public string? CXCustomerJourneyKeywordIDs { get; set; }
        public string? CXCustomerJourneyStage { get; set; }
        public float? CXCustomerJourneyScoreSnapshot { get; set; }
        public int? CreateBy { get; set; }
    }
}
