using WestCoastEducation.Models;
using WestCoastEducation.Services;

namespace WestCoastEducation;

class Program
{
    static void Main()
    {
        KursService service = new();

        KlassrumsKurs kurs1 = new()
        {
            Kursnummer = "WEB101",
            Title = "Grundläggande Webbutveckling",
            LangdDagar = 10,
            StartDatum = DateTime.Now.AddDays(30),
            SlutDatum = DateTime.Now.AddDays(40),
            SalPlats = "Sal 3B (Göteborg)"
        };

        DistansKurs kurs2 = new()
        {
            Kursnummer = "MOB201",
            Title = "Avancerad Mobilutveckling",
            LangdDagar = 15,
            StartDatum = DateTime.Now.AddDays(45),
            SlutDatum = DateTime.Now.AddDays(60),
            MotesLank = "https://teams.microsoft.com/..."
        };

        service.LäggTillKurs(kurs1);
        service.LäggTillKurs(kurs2);

        Studerande student = new()
        {
            Fornamn = "Abbe",
            Efternamn = "Babbe",
            Personnummer = "780909-1234",
            Telefon = "070-1234567",
            Adress = "Abc Gatan 49",
            Postnummer = "55555",
            Ort = "Onsala"
        };

        
        student.BokadeKurser.Add(kurs1);

        service.LäggTillStuderande(student);
        service.ListaKurser();
        service.ListaStudenter();
        
        List<Kurs> kurserAttSpara = new() { kurs1, kurs2 };
        JsonService.SparaKurserTillJson(kurserAttSpara);
    }
}