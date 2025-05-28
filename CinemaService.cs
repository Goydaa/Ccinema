using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class CinemaService
{
    private readonly AppDbContext _context;

    public CinemaService(AppDbContext context)
    {
        _context = context;
    }

    public void ShowMovies()
    {
        var movies = _context.Movies.Include(m => m.Genre).ToList();
        foreach (var movie in movies)
        {
            Console.WriteLine($"{movie.MovieId}. {movie.Title} ({movie.Genre.Name}) - {movie.DurationMinutes} мин");
        }
    }

    public void BookTicket(string userName, string phone, int screeningId, int row, int seat)
    {
        var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == phone);
        if (user == null)
        {
            user = new User { Name = userName, PhoneNumber = phone };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        var booking = new Booking
        {
            User = user,
            BookingTime = DateTime.Now
        };

        var ticket = _context.Tickets
            .FirstOrDefault(t => t.ScreeningId == screeningId && t.SeatRow == row && t.SeatNumber == seat && t.Booking == null);

        if (ticket == null)
        {
            Console.WriteLine("Место занято или не существует.");
            return;
        }

        ticket.Booking = booking;
        _context.Bookings.Add(booking);
        _context.SaveChanges();

        Console.WriteLine("Билет успешно забронирован.");
    }
}