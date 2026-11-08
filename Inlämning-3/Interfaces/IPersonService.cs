using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducation.Desktop.Models;

namespace WestCoastEducation.Desktop.Interfaces;

public interface IPersonService
{
    Task<List<Studerande>> GetStuderandeAsync();
    Task<bool> AddStuderandeAsync(Studerande studerande);
    Task<bool> UpdateStuderandeAsync(Studerande studerande);

    Task<List<Larare>> GetLarareAsync();
    Task<bool> AddLarareAsync(Larare larare);
    Task<bool> UpdateLarareAsync(Larare larare);
}