using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WestCoastEducation.Desktop.Interfaces;
using WestCoastEducation.Desktop.Models;

namespace WestCoastEducation.Desktop.Services;

public class RestDbService : IKursService, IPersonService
{
    private readonly HttpClient _client;

    public RestDbService(RestDbSettings settings)
    {
        _client = new HttpClient();
        
        if (!string.IsNullOrEmpty(settings.BaseUrl))
        {
            _client.BaseAddress = new Uri(settings.BaseUrl.EndsWith("/") ? settings.BaseUrl : settings.BaseUrl + "/");
        }
        
        if (!string.IsNullOrEmpty(settings.ApiKey))
        {
            _client.DefaultRequestHeaders.Add("x-apikey", settings.ApiKey);
        }
    }

    // Default-konstruktor om inga settings skickas in
    public RestDbService() : this(new RestDbSettings())
    {
    }

    // --- KURSER ---
    public async Task<List<Kurs>> GetKurserAsync()
    {
        try
        {
            var result = await _client.GetFromJsonAsync<List<Kurs>>("kurser");
            return result ?? new List<Kurs>();
        }
        catch
        {
            return new List<Kurs>();
        }
    }

    public async Task<bool> AddKursAsync(Kurs kurs)
    {
        try
        {
            var response = await _client.PostAsJsonAsync("kurser", kurs);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateKursAsync(Kurs kurs)
    {
        try
        {
            var response = await _client.PutAsJsonAsync($"kurser/{kurs.Id}", kurs);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteKursAsync(string id)
    {
        try
        {
            var response = await _client.DeleteAsync($"kurser/{id}");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    // --- STUDERANDE ---
    public async Task<List<Studerande>> GetStuderandeAsync()
    {
        try
        {
            var result = await _client.GetFromJsonAsync<List<Studerande>>("studerande");
            return result ?? new List<Studerande>();
        }
        catch
        {
            return new List<Studerande>();
        }
    }

    public async Task<bool> AddStuderandeAsync(Studerande studerande)
    {
        try
        {
            var response = await _client.PostAsJsonAsync("studerande", studerande);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateStuderandeAsync(Studerande studerande)
    {
        try
        {
            var response = await _client.PutAsJsonAsync($"studerande/{studerande.Id}", studerande);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    // --- LÄRARE ---
    public async Task<List<Larare>> GetLarareAsync()
    {
        try
        {
            var result = await _client.GetFromJsonAsync<List<Larare>>("larare");
            return result ?? new List<Larare>();
        }
        catch
        {
            return new List<Larare>();
        }
    }

    public async Task<bool> AddLarareAsync(Larare larare)
    {
        try
        {
            var response = await _client.PostAsJsonAsync("larare", larare);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateLarareAsync(Larare larare)
    {
        try
        {
            var response = await _client.PutAsJsonAsync($"larare/{larare.Id}", larare);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}