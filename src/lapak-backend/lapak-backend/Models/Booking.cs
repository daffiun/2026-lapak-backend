namespace lapak_backend.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string BorrowerName { get; set; } = string.Empty;
        public string BorrowerNrp { get; set; } = string.Empty;
        public string OperatorName { get; set; } = string.Empty;
        public DateTime StartDate { get; set;  }
        public DateTime EndDate { get; set; }
        public DateTime BookingDate { get; set; }
        public int RoomId { get; set; }
        public string Status { get; set; } = "Pending";
        public Room? Room { get; set; }
    }
}