namespace WestCoastEducation.Models
{
    public class Studerande : Person
    {
        public List<Kurs> BokadeKurser { get; set; } = new();

        public override string GetInfo()
        {
            return $"[Studerande] " + base.GetInfo();
        }
    }
}