using System.Reflection;

namespace ThePlannerAPI.Models
{
    public class PlannerEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }

        public string Color { get; set; }
        public int JobID { get; set; }
        public string ShipName { get; set; }
        public string JobCode { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public string DeparturePort { get; set; }
        public string ArrivalPort { get; set; }
        public string EditBy { get; set; }
        public int PlannerEventTypeId { get; set; }
        public PlannerEventType PlannerEventType { get; set; }
        public int TravelDays { get; set; }
        public bool IsCTS { get; set; }
    }
}
