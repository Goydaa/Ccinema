using System;

class Program
{
    static void Main()
    {
        // Создание подключения к базе данных
        using var context = new AppDbContext();

        // Если базы нет — будет создана
        context.Database.EnsureCreated();

        // Создание бизнес-логики
        var service = new CinemaService(context);

        while (true) // Цикл основного меню
        {
            Console.WriteLine("1. Показать фильмы");
            Console.WriteLine("2. Забронировать билет");
            Console.WriteLine("0. Выход");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    service.ShowMovies(); // Метод бизнес-логики
                    break;
                case "2":
                    Console.Write("Имя: ");
                    var name = Console.ReadLine();
                    Console.Write("Телефон: ");
                    var phone = Console.ReadLine();
                    Console.Write("ID сеанса: ");
                    int screeningId = int.Parse(Console.ReadLine());
                    Console.Write("Ряд: ");
                    int row = int.Parse(Console.ReadLine());
                    Console.Write("Место: ");
                    int seat = int.Parse(Console.ReadLine());

                    // Метод бронирования
                    service.BookTicket(name, phone, screeningId, row, seat);
                    break;
                case "0":
                    return; // Выход из программы
            }
        }
    }
}