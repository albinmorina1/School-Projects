using System;
using System.Text.Json.Serialization;

namespace WestCoastEducation.Desktop.Models;

public class Kurs
{
    [JsonPropertyName("_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    [JsonPropertyName("CourseNumber")]
    public string Kursnummer { get; set; } = string.Empty;

    [JsonPropertyName("Title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("LengthInDays")]
    public int LangdDagar { get; set; }

    [JsonPropertyName("StartDate")]
    public DateTime StartDatum { get; set; } = DateTime.Now;

    [JsonPropertyName("EndDate")]
    public DateTime SlutDatum { get; set; } = DateTime.Now.AddDays(30);
}

public class KlassrumsKurs : Kurs
{
    [JsonPropertyName("RoomLocation")]
    public string SalPlats { get; set; } = string.Empty;
}

public class DistansKurs : Kurs
{
    [JsonPropertyName("MeetingLink")]
    public string MotesLank { get; set; } = string.Empty;
}