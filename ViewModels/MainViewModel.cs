using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WestCoastEducation.Desktop.Interfaces;
using WestCoastEducation.Desktop.Models;

namespace WestCoastEducation.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IKursService _kursService;
    private readonly IPersonService _personService;

    public ObservableCollection<Kurs> Kurser { get; } = new();
    public ObservableCollection<Studerande> StuderandeLista { get; } = new();
    public ObservableCollection<Larare> LarareLista { get; } = new();

    private Kurs? _valdKurs;
    public Kurs? ValdKurs
    {
        get => _valdKurs;
        set
        {
            _valdKurs = value;
            OnPropertyChanged();
        }
    }

    private Studerande? _valdStuderande;
    public Studerande? ValdStuderande
    {
        get => _valdStuderande;
        set
        {
            _valdStuderande = value;
            OnPropertyChanged();
        }
    }

    private Larare? _valdLarare;
    public Larare? ValdLarare
    {
        get => _valdLarare;
        set
        {
            _valdLarare = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel()
    {
        _kursService = null!;
        _personService = null!;
    }

    public MainWindowViewModel(IKursService kursService, IPersonService personService)
    {
        _kursService = kursService;
        _personService = personService;

        _ = LaddaDataAsync();
    }

    public async Task LaddaDataAsync()
    {
        if (_kursService == null || _personService == null) return;

        Kurser.Clear();
        var kurser = await _kursService.GetKurserAsync();
        foreach (var k in kurser) Kurser.Add(k);

        StuderandeLista.Clear();
        var studerande = await _personService.GetStuderandeAsync();
        foreach (var s in studerande) StuderandeLista.Add(s);

        LarareLista.Clear();
        var larare = await _personService.GetLarareAsync();
        foreach (var l in larare) LarareLista.Add(l);
    }

    public async Task TaBortKursAsync()
    {
        if (ValdKurs == null || string.IsNullOrEmpty(ValdKurs.Id) || _kursService == null) return;

        var lyckades = await _kursService.DeleteKursAsync(ValdKurs.Id);
        if (lyckades)
        {
            Kurser.Remove(ValdKurs);
            ValdKurs = null;
        }
    }

    public async Task UppdateraKursAsync()
    {
        if (ValdKurs == null || string.IsNullOrEmpty(ValdKurs.Id) || _kursService == null) return;

        var lyckades = await _kursService.UpdateKursAsync(ValdKurs);
        if (lyckades)
        {
            var index = Kurser.IndexOf(ValdKurs);
            if (index >= 0)
            {
                var temp = ValdKurs;
                Kurser[index] = null!;
                Kurser[index] = temp;
                ValdKurs = temp;
            }
        }
    }

    public async Task UppdateraStuderandeAsync()
    {
        if (ValdStuderande == null || string.IsNullOrEmpty(ValdStuderande.Id) || _personService == null) return;

        var lyckades = await _personService.UpdateStuderandeAsync(ValdStuderande);
        if (lyckades)
        {
            var index = StuderandeLista.IndexOf(ValdStuderande);
            if (index >= 0)
            {
                var temp = ValdStuderande;
                StuderandeLista[index] = null!;
                StuderandeLista[index] = temp;
                ValdStuderande = temp;
            }
        }
    }

    public async Task UppdateraLarareAsync()
    {
        if (ValdLarare == null || string.IsNullOrEmpty(ValdLarare.Id) || _personService == null) return;

        var lyckades = await _personService.UpdateLarareAsync(ValdLarare);
        if (lyckades)
        {
            var index = LarareLista.IndexOf(ValdLarare);
            if (index >= 0)
            {
                var temp = ValdLarare;
                LarareLista[index] = null!;
                LarareLista[index] = temp;
                ValdLarare = temp;
            }
        }
    }
}