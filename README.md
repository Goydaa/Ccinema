Cinema Booking System — это приложение для управления бронированием билетов в кинотеатре. Система позволяет:

Просматривать список доступных фильмов и сеансов

Бронировать места в зале

Управлять пользователями и их бронированиями

Просматривать историю покупок

Структура базы данных
Система включает 7 основных таблиц:

Movies - информация о фильмах

Screenings - расписание показов

Halls - информация о кинозалах

Users - данные клиентов

Tickets - информация о бронированиях

Bookings - подтвержденные покупки

Genres - категории фильмов

![image](https://github.com/user-attachments/assets/ab01153b-19e9-4444-9a40-86a08b0056fc)



  Cinema Booking System — Структура базы данных

 Таблицы:
 `Movie`: фильмы (id, title, duration)
 `Genre`: жанры
 `MovieGenre`: связь многие ко многим между Movie и Genre
 `Hall`: залы (id, name, row, seat)
 `Screening`: сеансы (date_time, movie_id, hall_id)
 `Visitor`: посетители
 `Ticket`: билеты (связь с сеансом и посетителем)
 `Booking`: подтверждённые бронирования (один к одному с Ticket)

 Типы связей:
 Один ко многим: Movie -> Screening, Visitor -> Ticket
 Многие ко многим: Movie <-> Genre через MovieGenre
 Один к одному: Ticket -> Booking
