using System.Collections.Generic;

namespace DBSalesApi.Models
{
    public class DashboardData
    {
        public int TotalCallsAttempt { get; set; }
        public int MeaningFullCalls { get; set; }
        public int QuotationIssued { get; set; }
        public decimal QuotationValue { get; set; }
        public int BusinessClosed { get; set; }
        public List<SalesAgents> SalesAgents { get; set; }
    }
}