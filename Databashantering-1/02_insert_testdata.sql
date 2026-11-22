PRAGMA foreign_keys = ON;

-- Lägg till leverantörer
INSERT INTO Leverantorer (Namn, Adress, Kontaktperson, Telefon, Epost) VALUES
('Kvarnen AB', 'Mjölvägen 12, 302 45 Halmstad', 'Anders Svensson', '035-123456', 'anders@kvarnen.se'),
('Mejerigården', 'Kogatan 4, 311 32 Falkenberg', 'Karin Lind', '0346-654321', 'karin@mejerigarden.se'),
('Sockerbruket Syd', 'Betvägen 88, 211 20 Malmö', 'Johan Berg', '040-987654', 'johan@sockerbruket.se');

-- Lägg till råvaror
INSERT INTO Ravaror (LeverantorId, Artikelnummer, Namn, PrisPerKg, LagersaldoKg, MinimiNivaKg) VALUES
(1, 'KV-101', 'Vetemjöl Special', 12.50, 45.0, 20.0),
(1, 'KV-102', 'Rågsikt', 14.00, 8.0, 15.0),      
(2, 'MJ-201', 'Äkta Smör 82%', 68.00, 12.0, 10.0),
(2, 'MJ-202', 'Vispgrädde 40%', 42.00, 4.0, 6.0),     
(3, 'SB-301', 'Strösocker', 15.00, 30.0, 10.0),
(3, 'SB-302', 'Kanel Malen', 110.00, 2.5, 1.0);

-- Lägg till bageriprodukter
INSERT INTO Produkter (Namn, Kategori) VALUES
('Kanelbulle', 'Bullar'),
('Surdegsrågbröd', 'Bröd'),
('Prinsesstårta', 'Konditoriprodukter');

-- Lägg till recept
-- Kanelbulle
INSERT INTO Recept (ProduktId, RavaraId, MangdKg) VALUES
(1, 1, 0.050), -- Vetemjöl
(1, 3, 0.015), -- Smör
(1, 5, 0.012), -- Strösocker
(1, 6, 0.003); -- Kanel

-- Surdegsrågbröd
INSERT INTO Recept (ProduktId, RavaraId, MangdKg) VALUES
(2, 1, 0.200), -- Vetemjöl
(2, 2, 0.300); -- Rågsikt

-- Prinsesstårta
INSERT INTO Recept (ProduktId, RavaraId, MangdKg) VALUES
(3, 1, 0.150), -- Vetemjöl
(3, 4, 0.400), -- Vispgrädde
(3, 5, 0.200); -- Strösocker

-- Registrera gjorda inköp
INSERT INTO Inkop (RavaraId, InkopsDatum, MangdKg, PrisPerKgVidKop) VALUES
(1, '2026-11-01', 50.0, 12.50),
(2, '2026-11-05', 25.0, 14.00),
(3, '2026-11-10', 20.0, 68.00),
(4, '2026-11-15', 10.0, 42.00),
(5, '2026-11-18', 30.0, 15.00);