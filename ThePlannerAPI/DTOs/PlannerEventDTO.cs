using Microsoft.AspNetCore.Mvc;

namespace ThePlannerAPI.DTOs
{
    public class PlannerEventDTO
    {
        [FromForm(Name = "id")]
        public int Id { get; set; }

        public string Name { get; set; }

        [FromForm(Name = "start_date")]
        public DateTime StartDate { get; set; }

        [FromForm(Name = "end_date")]
        public DateTime EndDate { get; set; }

        [FromForm(Name = "section_id")]
        public int Resource { get; set; }

        public string Color { get; set; }

        public int JobID { get; set; }

        public string ShipName { get; set; }

        public string JobCode { get; set; }

        [FromForm(Name = "text")]
        public string Description { get; set; }

        public string ClientName { get; set; }

        public string DeparturePort { get; set; }

        public string ArrivalPort { get; set; }

        public string EditBy { get; set; }

        public int PlannerEventType { get; set; }

        public int TravelDays { get; set; }

        public bool IsCTS { get; set; }
    }
}
