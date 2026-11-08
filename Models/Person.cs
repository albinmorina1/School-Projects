using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WestCoastEducation.Desktop.Models;

public abstract class Person
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; }

    public string Fornamn { get; set; } = string.Empty;
    public string Efternamn { get; set; } = string.Empty;
    public string Personnummer { get; set; } = string.Empty;
    public string Telefon { get; set; } = string.Empty;
    public string Epost { get; set; } = string.Empty;
}

public class Studerande : Person
{
    public string Adress { get; set; } = string.Empty;
    public string Postnummer { get; set; } = string.Empty;
    public string Ort { get; set; } = string.Empty;
    public List<string> BokadeKursIdn { get; set; } = new();
}

public class Larare : Person
{
    // Hantera en lärares kompetensområde (Krav för VG/G)
    public List<string> Kompetensomraden { get; set; } = new();
}