
CREATE TABLE Genre (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);

CREATE TABLE Movie (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    title TEXT NOT NULL,
    duration INTEGER NOT NULL
);

CREATE TABLE MovieGenre (
    movie_id INTEGER,
    genre_id INTEGER,
    PRIMARY KEY (movie_id, genre_id),
    FOREIGN KEY (movie_id) REFERENCES Movie(id),
    FOREIGN KEY (genre_id) REFERENCES Genre(id)
);

CREATE TABLE Hall (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    row INTEGER NOT NULL,
    seat INTEGER NOT NULL
);

CREATE TABLE Screening (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    date_time TEXT NOT NULL,
    movie_id INTEGER NOT NULL,
    hall_id INTEGER NOT NULL,
    FOREIGN KEY (movie_id) REFERENCES Movie(id),
    FOREIGN KEY (hall_id) REFERENCES Hall(id)
);

CREATE TABLE Visitor (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    phone TEXT
);

CREATE TABLE Ticket (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    screening_id INTEGER NOT NULL,
    visitor_id INTEGER NOT NULL,
    seat_number TEXT NOT NULL,
    age_limit INTEGER,
    FOREIGN KEY (screening_id) REFERENCES Screening(id),
    FOREIGN KEY (visitor_id) REFERENCES Visitor(id)
);

CREATE TABLE Booking (
    id TEXT PRIMARY KEY,
    ticket_id INTEGER UNIQUE,
    FOREIGN KEY (ticket_id) REFERENCES Ticket(id)
);
