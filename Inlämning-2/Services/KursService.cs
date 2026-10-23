using WestCoastEducation.Models;

namespace WestCoastEducation.Services
{
    public class KursService
    {
        private List<Kurs> _kurser = new();
        private List<Studerande> _studerande = new();

        public void LäggTillKurs(Kurs kurs)
        {
            if (kurs != null && !string.IsNullOrEmpty(kurs.Kursnummer))
            {
                _kurser.Add(kurs);
                Console.WriteLine($"Kursen '{kurs.Title}' har lagts till.");
            }
        }

        public void ListaKurser()
        {
            if (_kurser.Count == 0)
            {
                Console.WriteLine("Inga kurser finns registrerade.");
                return;
            }

            Console.WriteLine("\n--- LISTA ÖVER KURSER ---");
            
            foreach (var kurs in _kurser)
            {
                Console.WriteLine(kurs.GetCourseDetails());
            }
        }

        public void LäggTillStuderande(Studerande student)
        {
            if (student != null)
            {
                _studerande.Add(student);
                Console.WriteLine($"Studerande {student.Fornamn} {student.Efternamn} har lagts till.");
            }
        }

        public void ListaStudenter()
        {
            Console.WriteLine("\n--- LISTA ÖVER STUDERANDE ---");
            if (_studerande.Count == 0)
            {
                Console.WriteLine("Inga studenter registrerade.");
                return;
            }

            for (int i = 0; i < _studerande.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_studerande[i].GetInfo()}");
            }
        }
    }
}