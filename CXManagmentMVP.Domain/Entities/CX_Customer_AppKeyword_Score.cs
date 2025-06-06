﻿namespace CXManagmentMVP.Domain.Entities
{
    public class CX_Customer_AppKeyword_Score
    {
        public int CXCAKScoreID { get; set; }
        public int? CXCustomerID { get; set; }
        public int? CXASKID { get; set; }
        public float? CXCAKCalculatedScore { get; set; }
        public DateTime? CXCAKCalculatedDate { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public int? CreateBy { get; set; }

        public CX_Customer? Customer { get; set; }
        public CX_Application_Keyword? ApplicationKeyword { get; set; }
    }
}
