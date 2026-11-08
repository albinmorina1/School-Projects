using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducation.Desktop.Models;

namespace WestCoastEducation.Desktop.Interfaces;

public interface IKursService
{
    Task<List<Kurs>> GetKurserAsync();
    Task<bool> AddKursAsync(Kurs kurs);
    Task<bool> UpdateKursAsync(Kurs kurs);
    Task<bool> DeleteKursAsync(string id);
}