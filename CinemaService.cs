using System;
using System.Collections.Generic;

public class CinemaService
{
    private Database _db;

    public CinemaService(Database db)
    {
        _db = db;
    }

    public List<string> ListAvailableMovies()
    {
        return _db.GetMovies();
    }

    public List<string> GetScreeningsForMovie(int movieId)
    {
        return _db.GetScreeningsByMovie(movieId);
    }

    public bool TryBookTicket(int screeningId, int userId, string seatNumber, int userAge, int ageLimit)
    {
        if (userAge < ageLimit)
        {
            Console.WriteLine("Ошибка: возраст пользователя ниже возрастного ограничения фильма.");
            return false;
        }

        try
        {
            _db.BookTicket(screeningId, userId, seatNumber, ageLimit);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при бронировании билета: " + ex.Message);
            return false;
        }
    }
}
