namespace WestCoastEducation.Interfaces
{
    public interface ICourse
    {
        string Kursnummer { get; set; }
        string Title { get; set; }
        int LangdDagar { get; set; }
        DateTime StartDatum { get; set; }
        DateTime SlutDatum { get; set; }
        string GetCourseDetails();
    }
}