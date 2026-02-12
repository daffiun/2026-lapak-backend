namespace lapak_backend.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string BorrowerName { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } = "Pending";
    }
}