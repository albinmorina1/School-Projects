# Mormor Dagnys Bageri – Databasdesign (SQLite)

Normaliserad relationsdatabas (3NF) i SQLite som hanterar leverantörer, råvaror, lagersaldo, inköp, bageriprodukter och recept med `FOREIGN KEY`-restriktioner.

## Visualiserad databasdesign (ER-modell)

```text
+-------------------+       +-------------------+       +-------------------+
|   Leverantorer    |       |      Ravaror      |       |      Inkop        |
+-------------------+       +-------------------+       +-------------------+
| PK LeverantorId   |---<   | PK RavaraId       |---<   | PK InkopId        |
|    Namn           |       | FK LeverantorId   |       | FK RavaraId       |
|    Adress         |       |    Artikelnummer  |       |    InkopsDatum    |
|    Kontaktperson  |       |    Namn           |       |    MangdKg        |
|    Telefon        |       |    PrisPerKg      |       |    PrisPerKgVidKop|
|    Epost          |       |    LagersaldoKg   |       +-------------------+
+-------------------+       |    MinimiNivaKg   |
                            +-------------------+
                                      |
                                      | (1:N)
                                      v
+-------------------+       +-------------------+
|     Produkter     |       |      Recept       |
+-------------------+       +-------------------+
| PK ProduktId      |---<   | PK,FK ProduktId   |
|    Namn           |       | PK,FK RavaraId    |
|    Kategori       |       |    MangdKg        |
+-------------------+       +-------------------+

```


##Databasskript
01_create_tables.sql – Skapar tabellstrukturen med primär- och främmande nycklar (PRAGMA foreign_keys = ON).

02_insert_testdata.sql – Fyller databasen med testdata för leverantörer, råvaror, produkter, recept och inköp.

03_test_queries.sql – Testfrågor som listar produkter med tillhörande råvaror och leverantörer, inköpshistorik samt råvaror under beställningsnivå.
