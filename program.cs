
using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Cinema Booking System ===");
            Console.WriteLine("1. Посмотреть список фильмов");
            Console.WriteLine("2. Посмотреть сеансы фильма");
            Console.WriteLine("3. Забронировать билет");
            Console.WriteLine("4. Посмотреть мои бронирования");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите пункт меню: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowMovies();
                    break;
                case "2":
                    ShowScreenings();
                    break;
                case "3":
                    BookTicket();
                    break;
                case "4":
                    ShowBookings();
                    break;
                case "5":
                    Console.WriteLine("Выход из программы...");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите Enter и попробуйте снова.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ShowMovies()
    {
        Console.WriteLine("\n[Показ фильмов]");
        // Здесь будет код для вывода фильмов из БД
        Console.WriteLine("Функция пока не реализована.");
        Console.WriteLine("Нажмите Enter для возврата в меню...");
        Console.ReadLine();
    }

    static void ShowScreenings()
    {
        Console.WriteLine("\n[Показ сеансов]");
        // Здесь будет код для вывода сеансов
        Console.WriteLine("Функция пока не реализована.");
        Console.WriteLine("Нажмите Enter для возврата в меню...");
        Console.ReadLine();
    }

    static void BookTicket()
    {
        Console.WriteLine("\n[Бронирование билета]");
        // Здесь будет код для бронирования билета
        Console.WriteLine("Функция пока не реализована.");
        Console.WriteLine("Нажмите Enter для возврата в меню...");
        Console.ReadLine();
    }

    static void ShowBookings()
    {
        Console.WriteLine("\n[Ваши бронирования]");
        // Здесь будет код для вывода бронирований
        Console.WriteLine("Функция пока не реализована.");
        Console.WriteLine("Нажмите Enter для возврата в меню...");
        Console.ReadLine();
    }
}
