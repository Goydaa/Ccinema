
using System;
using System.Collections.Generic;

public class CinemaService
{
    private Database _db;

    public CinemaService(Database db)
    {
        _db = db;
    }

    // Получение списка фильмов
    public List<string> ListAvailableMovies()
    {
        return _db.GetMovies();
    }

    // Получение сеансов по ID фильма
    public List<string> GetScreeningsForMovie(int movieId)
    {
        return _db.GetScreeningsByMovie(movieId);
    }

    // Получение свободных мест (заглушка)
    public List<string> GetFreeSeats(int screeningId)
    {
        // Тут должна быть логика получения занятых мест из БД
        return new List<string> { "A1", "A2", "A3", "B1", "B2" };
    }

    // Бронирование билета с проверкой возраста
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

    // Получение списка бронирований пользователя (заглушка)
    public List<string> GetUserBookings(int userId)
    {
        return new List<string> { $"Бронь: Сеанс 1, Место A1", $"Бронь: Сеанс 2, Место B2" };
    }

    // Отмена бронирования (заглушка)
    public bool CancelBooking(int bookingId, int userId)
    {
        Console.WriteLine($"Бронирование {bookingId} отменено.");
        return true;
    }
}
