namespace lapak_backend.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string OperatorName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}