public class Screening
{
    public int ScreeningId { get; set; }
    public DateTime StartTime { get; set; }

    public int MovieId { get; set; }
    public Movie Movie { get; set; }

    public int HallId { get; set; }
    public Hall Hall { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}