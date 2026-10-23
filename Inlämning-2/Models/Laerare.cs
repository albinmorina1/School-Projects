namespace WestCoastEducation.Models
{
    public class Laerare : Person
    {
        public string Kunskapsomrade { get; set; } = string.Empty;
        public List<string> AnsvarigaKurser { get; set; } = new();

        public override string GetInfo()
        {
            return $"[Lärare] " + base.GetInfo() + $", Område: {Kunskapsomrade}";
        }
    }
}