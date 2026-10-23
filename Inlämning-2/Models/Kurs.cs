using WestCoastEducation.Interfaces;

namespace WestCoastEducation.Models
{
    public abstract class Kurs : ICourse
    {
        public string Kursnummer { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int LangdDagar { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }

        public virtual string GetCourseDetails()
        {
            return $"Kursnr: {Kursnummer} | {Title} | Längd: {LangdDagar} dagar | Start: {StartDatum.ToShortDateString()}";
        }
    }

    public class KlassrumsKurs : Kurs
    {
        public string SalPlats { get; set; } = string.Empty;

        public override string GetCourseDetails()
        {
            return base.GetCourseDetails() + $" | Typ: Klassrum (Sal: {SalPlats})";
        }
    }

    public class DistansKurs : Kurs
    {
        public string MotesLank { get; set; } = string.Empty;

        public override string GetCourseDetails()
        {
            return base.GetCourseDetails() + $" | Typ: Distans (Länk: {MotesLank})";
        }
    }
}