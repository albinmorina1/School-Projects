namespace WestCoastEducation.Models
{
    public class Administratör : Utbildningsledare
    {
        
        public override string GetInfo()
        {
            return $"[Administratör] {Fornamn} {Efternamn}, Anställd: {Anstallningsdatum.ToShortDateString()}";
        }
    }
}