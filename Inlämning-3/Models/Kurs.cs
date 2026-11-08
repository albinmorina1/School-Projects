using System;
using System.Text.Json.Serialization;

namespace WestCoastEducation.Desktop.Models;

public class Kurs
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; }

    public string Kursnummer { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int LangdDagar { get; set; }
    public DateTime StartDatum { get; set; } = DateTime.Now;
    public DateTime SlutDatum { get; set; } = DateTime.Now.AddDays(30);
}

public class KlassrumsKurs : Kurs
{
    public string SalPlats { get; set; } = string.Empty;
}

public class DistansKurs : Kurs
{
    public string MotesLank { get; set; } = string.Empty;
}