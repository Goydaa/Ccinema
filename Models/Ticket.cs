public class Ticket
{
    public int TicketId { get; set; }
    public int SeatRow { get; set; }
    public int SeatNumber { get; set; }

    public int ScreeningId { get; set; }
    public Screening Screening { get; set; }

    public int? BookingId { get; set; }
    public Booking Booking { get; set; }
}