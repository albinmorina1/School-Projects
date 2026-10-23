using System.Text.Json;
using WestCoastEducation.Models;
using System.IO; 

namespace WestCoastEducation.Services;

public static class JsonService
{
    
    private static readonly string FolderPath = Path.Combine(Environment.CurrentDirectory, "Data");
    private static readonly string FilePath = Path.Combine(FolderPath, "kurser.json");

    public static void SparaKurserTillJson(List<Kurs> kurser)
    {
        
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(kurser, options);
        File.WriteAllText(FilePath, jsonString);
        Console.WriteLine("\nKurser har sparats till Data/kurser.json.");
    }

    public static List<Kurs> LäsKurserFrånJson()
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("Ingen JSON-fil hittades.");
            return new List<Kurs>();
        }

        string jsonString = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Kurs>>(jsonString) ?? new List<Kurs>();
    }
}