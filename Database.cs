
using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class Database
{
    private SQLiteConnection connection;

    public void Connect(string dbPath)
    {
        try
        {
            connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            connection.Open();
            Console.WriteLine("Успешное подключение к базе данных.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка подключения к базе данных: " + ex.Message);
        }
    }

    public void Close()
    {
        if (connection != null)
        {
            connection.Close();
        }
    }

    public List<string> GetMovies()
    {
        var movies = new List<string>();
        try
        {
            string query = "SELECT id, title FROM Movie;";
            var cmd = new SQLiteCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                movies.Add($"ID: {reader["id"]} | {reader["title"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при получении фильмов: " + ex.Message);
        }
        return movies;
    }

    public List<string> GetScreeningsByMovie(int movieId)
    {
        var screenings = new List<string>();
        try
        {
            string query = @"
                SELECT s.id, s.date_time, h.name 
                FROM Screening s
                JOIN Hall h ON s.hall_id = h.id
                WHERE s.movie_id = @movieId;";
            var cmd = new SQLiteCommand(query, connection);
            cmd.Parameters.AddWithValue("@movieId", movieId);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                screenings.Add($"ID: {reader["id"]} | Время: {reader["date_time"]} | Зал: {reader["name"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при получении сеансов: " + ex.Message);
        }
        return screenings;
    }

    public void BookTicket(int screeningId, int visitorId, string seatNumber, int ageLimit)
    {
        try
        {
            string insertTicket = @"
                INSERT INTO Ticket (screening_id, visitor_id, seat_number, age_limit)
                VALUES (@screeningId, @visitorId, @seatNumber, @ageLimit);";

            var cmd = new SQLiteCommand(insertTicket, connection);
            cmd.Parameters.AddWithValue("@screeningId", screeningId);
            cmd.Parameters.AddWithValue("@visitorId", visitorId);
            cmd.Parameters.AddWithValue("@seatNumber", seatNumber);
            cmd.Parameters.AddWithValue("@ageLimit", ageLimit);
            cmd.ExecuteNonQuery();

            long ticketId = connection.LastInsertRowId;

            string insertBooking = "INSERT INTO Booking (id, ticket_id) VALUES (@id, @ticketId);";
            var cmd2 = new SQLiteCommand(insertBooking, connection);
            cmd2.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
            cmd2.Parameters.AddWithValue("@ticketId", ticketId);
            cmd2.ExecuteNonQuery();

            Console.WriteLine("Билет успешно забронирован.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при бронировании билета: " + ex.Message);
        }
    }
}
