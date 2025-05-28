public class CinemaService
{
    private List<string> movies = new List<string>
    {
        "The Matrix",
        "Inception",
        "Interstellar"
    };

    public void ShowAllMovies()
    {
        Console.WriteLine("\nДоступные фильмы:");
        foreach (var movie in movies)
        {
            Console.WriteLine($"- {movie}");
        }
    }

    public void BookTicket(string movieName)
    {
        if (movies.Contains(movieName))
        {
            Console.WriteLine($"Билет забронирован: {movieName}");
        }
        else
        {
            Console.WriteLine("Фильм не найден.");
        }
    }
}

