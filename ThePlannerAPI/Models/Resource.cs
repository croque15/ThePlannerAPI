namespace ThePlannerAPI.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResourceType { get; set; } // "Person", "Vehicle", "Item"
    }
}
