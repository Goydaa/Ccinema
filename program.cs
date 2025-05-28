class Program
{
    static void Main(string[] args)
    {
        Database.Init(); // инициализация БД (пока что заглушка)
        var cinemaService = new CinemaService();

        while (true)
        {
            Console.WriteLine("\n===== Cinema Booking System =====");
            Console.WriteLine("1. Показать фильмы");
            Console.WriteLine("2. Забронировать билет");
            Console.WriteLine("3. Выйти");
            Console.Write("Выберите действие: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    cinemaService.ShowAllMovies();
                    break;
                case "2":
                    Console.Write("Введите название фильма: ");
                    var movie = Console.ReadLine();
                    cinemaService.BookTicket(movie);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Повторите.");
                    break;
            }
        }
    }
}
