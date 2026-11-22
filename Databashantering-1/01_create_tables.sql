PRAGMA foreign_keys = ON;

DROP TABLE IF EXISTS Inkop;
DROP TABLE IF EXISTS Recept;
DROP TABLE IF EXISTS Produkter;
DROP TABLE IF EXISTS Ravaror;
DROP TABLE IF EXISTS Leverantorer;

CREATE TABLE Leverantorer (
    LeverantorId INTEGER PRIMARY KEY AUTOINCREMENT,
    Namn TEXT NOT NULL,
    Adress TEXT NOT NULL,
    Kontaktperson TEXT NOT NULL,
    Telefon TEXT NOT NULL,
    Epost TEXT NOT NULL UNIQUE
);


CREATE TABLE Ravaror (
    RavaraId INTEGER PRIMARY KEY AUTOINCREMENT,
    LeverantorId INTEGER NOT NULL,
    Artikelnummer TEXT NOT NULL UNIQUE,
    Namn TEXT NOT NULL,
    PrisPerKg REAL NOT NULL CHECK (PrisPerKg >= 0),
    LagersaldoKg REAL NOT NULL DEFAULT 0 CHECK (LagersaldoKg >= 0),
    MinimiNivaKg REAL NOT NULL DEFAULT 5.0 CHECK (MinimiNivaKg >= 0),
    FOREIGN KEY (LeverantorId) REFERENCES Leverantorer(LeverantorId)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);


CREATE TABLE Produkter (
    ProduktId INTEGER PRIMARY KEY AUTOINCREMENT,
    Namn TEXT NOT NULL UNIQUE,
    Kategori TEXT NOT NULL CHECK (Kategori IN ('Bullar', 'Bröd', 'Konditoriprodukter'))
);


CREATE TABLE Recept (
    ProduktId INTEGER NOT NULL,
    RavaraId INTEGER NOT NULL,
    MangdKg REAL NOT NULL CHECK (MangdKg > 0),
    PRIMARY KEY (ProduktId, RavaraId),
    FOREIGN KEY (ProduktId) REFERENCES Produkter(ProduktId)
        ON UPDATE CASCADE
        ON DELETE CASCADE,
    FOREIGN KEY (RavaraId) REFERENCES Ravaror(RavaraId)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);


CREATE TABLE Inkop (
    InkopId INTEGER PRIMARY KEY AUTOINCREMENT,
    RavaraId INTEGER NOT NULL,
    InkopsDatum TEXT NOT NULL DEFAULT (DATE('now')),
    MangdKg REAL NOT NULL CHECK (MangdKg > 0),
    PrisPerKgVidKop REAL NOT NULL CHECK (PrisPerKgVidKop >= 0),
    FOREIGN KEY (RavaraId) REFERENCES Ravaror(RavaraId)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);