using Microsoft.AspNetCore.Mvc;

namespace ThePlannerAPI.DTOs
{
    public class PlannerEventDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int Resource { get; set; }
        public string Color { get; set; }
        public int JobID { get; set; }
        public string ShipName { get; set; }
        public string JobCode { get; set; }
        public string text { get; set; }
        public string ClientName { get; set; }
        public string DeparturePort { get; set; }
        public string ArrivalPort { get; set; }
        public string EditBy { get; set; }
        public int PlannerEventType { get; set; }
        public int TravelDays { get; set; }
        public bool IsC { get; set; }
    }
}
