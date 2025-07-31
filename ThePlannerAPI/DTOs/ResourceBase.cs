namespace
{
    public abstract class ResourceBase
    {
        public int Key { get; set; }
        public string Label { get; set; }

    }
}

namespace ThePlannerAPI.DTOs
{
    public class EmployeeDTO : ResourceBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sector { get; set; }
        public DateTime? MedCert { get; set; }
        public int Days { get; set; }
        public string ResourceType { get; set; }
    }
}