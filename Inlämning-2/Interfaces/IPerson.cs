namespace WestCoastEducation.Interfaces
{
    public interface IPerson
    {
        string Fornamn { get; set; }
        string Efternamn { get; set; }
        string Personnummer { get; set; }
        string Telefon { get; set; }
        string Adress { get; set; }
        string Postnummer { get; set; }
        string Ort { get; set; }
        string GetInfo();
    }
}