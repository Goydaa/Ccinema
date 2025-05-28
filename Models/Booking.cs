public class Booking
{
    public int BookingId { get; set; }
    public DateTime BookingTime { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}