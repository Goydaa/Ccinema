public class Hall
{
    public int HallId { get; set; }
    public string Name { get; set; }
    public int Rows { get; set; }
    public int SeatsPerRow { get; set; }

    public ICollection<Screening> Screenings { get; set; }
}