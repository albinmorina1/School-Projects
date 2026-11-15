using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WestCoastEducation.Desktop.Models;

public abstract class Person
{
    [JsonPropertyName("_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    [JsonPropertyName("FirstName")]
    public string Fornamn { get; set; } = string.Empty;

    [JsonPropertyName("LastName")]
    public string Efternamn { get; set; } = string.Empty;

    [JsonPropertyName("PersonalNumber")]
    public string Personnummer { get; set; } = string.Empty;

    [JsonPropertyName("Phone")]
    public string Telefon { get; set; } = string.Empty;

    [JsonPropertyName("Email")]
    public string Epost { get; set; } = string.Empty;
}

public class Studerande : Person
{
    [JsonPropertyName("Street")]
    public string Adress { get; set; } = string.Empty;

    [JsonPropertyName("PostalCode")]
    public string Postnummer { get; set; } = string.Empty;

    [JsonPropertyName("City")]
    public string Ort { get; set; } = string.Empty;

    [JsonPropertyName("BookedCourseIds")]
    public List<string> BokadeKursIdn { get; set; } = new();
}

public class Larare : Person
{
    [JsonPropertyName("Expertise")]
    public List<string> Kompetensomraden { get; set; } = new();
}