PRAGMA foreign_keys = ON;

SELECT 
    p.Namn AS Produkt,
    p.Kategori,
    r.Namn AS Ravara,
    rec.MangdKg AS MangdPerEnhetKg,
    l.Namn AS Leverantor,
    l.Kontaktperson,
    l.Telefon
FROM Produkter p
JOIN Recept rec ON p.ProduktId = rec.ProduktId
JOIN Ravaror r ON rec.RavaraId = r.RavaraId
JOIN Leverantorer l ON r.LeverantorId = l.LeverantorId
ORDER BY p.Namn, r.Namn;

SELECT 
    r.Artikelnummer,
    r.Namn AS Ravara,
    r.LagersaldoKg AS KvarILagerKg,
    r.MinimiNivaKg AS BestallningspunktKg,
    l.Namn AS Leverantor,
    l.Epost AS BestallningsEpost
FROM Ravaror r
JOIN Leverantorer l ON r.LeverantorId = l.LeverantorId
WHERE r.LagersaldoKg < r.MinimiNivaKg;

SELECT 
    i.InkopsDatum,
    l.Namn AS Leverantor,
    r.Artikelnummer,
    r.Namn AS Ravara,
    i.MangdKg,
    i.PrisPerKgVidKop,
    ROUND(i.MangdKg * i.PrisPerKgVidKop, 2) AS TotalKostnadKr
FROM Inkop i
JOIN Ravaror r ON i.RavaraId = r.RavaraId
JOIN Leverantorer l ON r.LeverantorId = l.LeverantorId
ORDER BY i.InkopsDatum DESC;

