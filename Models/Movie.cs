public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public int DurationMinutes { get; set; }

    public int GenreId { get; set; }
    public Genre Genre { get; set; }

    public ICollection<Screening> Screenings { get; set; }
}