namespace lapak_backend.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public int BuildingId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string HeadOfRoom { get; set; } = string.Empty;
        public Building? Building { get; set; }
    }
}