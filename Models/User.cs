public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}