namespace WestCoastEducation.Models
{
    public class Utbildningsledare : Laerare
    {
        public DateTime Anstallningsdatum { get; set; }

        public override string GetInfo()
        {
            return $"[Utbildningsledare] {Fornamn} {Efternamn}, Anställd: {Anstallningsdatum.ToShortDateString()}";
        }
    }
}