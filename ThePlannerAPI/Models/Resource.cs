namespace ThePlannerAPI.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sector { get; set; }
        public DateTime? MedCert { get; set; }
        public int Hours { get; set; }
        public string ResourceType { get; set; } // Supervisor, Technician, etc.
    }
}
