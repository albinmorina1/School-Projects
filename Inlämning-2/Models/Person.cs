using WestCoastEducation.Interfaces;

namespace WestCoastEducation.Models
{
    public abstract class Person : IPerson
    {
        public string Fornamn { get; set; } = string.Empty;
        public string Efternamn { get; set; } = string.Empty;
        public string Personnummer { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Postnummer { get; set; } = string.Empty;
        public string Ort { get; set; } = string.Empty;

        public virtual string GetInfo()
        {
            return $"{Fornamn} {Efternamn}, PNR: {Personnummer}, Tel: {Telefon}, Adress: {Adress}, {Postnummer} {Ort}";
        }
    }
}