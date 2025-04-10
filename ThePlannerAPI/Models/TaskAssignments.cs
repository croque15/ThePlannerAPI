namespace ThePlannerAPI.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public int PersonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
