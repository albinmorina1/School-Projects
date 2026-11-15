using System;
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
    public ObservableCollection<string> ValdLarareKompetenser { get; } = new();

    private Kurs? _valdKurs;
    public Kurs? ValdKurs
    {
        get => _valdKurs;
        set { _valdKurs = value; OnPropertyChanged(); }
    }

    private Studerande? _valdStuderande;
    public Studerande? ValdStuderande
    {
        get => _valdStuderande;
        set { _valdStuderande = value; OnPropertyChanged(); }
    }

    private Larare? _valdLarare;
    public Larare? ValdLarare
    {
        get => _valdLarare;
        set
        {
            _valdLarare = value;
            OnPropertyChanged();
            UppdateraKompetensLista();
        }
    }

    // --- Fält för att skapa NY KURS ---
    private string _nyKursNummer = string.Empty;
    public string NyKursNummer { get => _nyKursNummer; set { _nyKursNummer = value; OnPropertyChanged(); } }

    private string _nyKursTitel = string.Empty;
    public string NyKursTitel { get => _nyKursTitel; set { _nyKursTitel = value; OnPropertyChanged(); } }

    private string _nyKursLangd = "30";
    public string NyKursLangd { get => _nyKursLangd; set { _nyKursLangd = value; OnPropertyChanged(); } }

    // --- Fält för att skapa NY STUDENT ---
    private string _nyStudentFornamn = string.Empty;
    public string NyStudentFornamn { get => _nyStudentFornamn; set { _nyStudentFornamn = value; OnPropertyChanged(); } }

    private string _nyStudentEfternamn = string.Empty;
    public string NyStudentEfternamn { get => _nyStudentEfternamn; set { _nyStudentEfternamn = value; OnPropertyChanged(); } }

    private string _nyStudentPersonnummer = string.Empty;
    public string NyStudentPersonnummer { get => _nyStudentPersonnummer; set { _nyStudentPersonnummer = value; OnPropertyChanged(); } }

    private string _nyStudentTelefon = string.Empty;
    public string NyStudentTelefon { get => _nyStudentTelefon; set { _nyStudentTelefon = value; OnPropertyChanged(); } }

    private string _nyStudentEpost = string.Empty;
    public string NyStudentEpost { get => _nyStudentEpost; set { _nyStudentEpost = value; OnPropertyChanged(); } }

    private string _nyStudentAdress = string.Empty;
    public string NyStudentAdress { get => _nyStudentAdress; set { _nyStudentAdress = value; OnPropertyChanged(); } }

    private string _nyStudentPostnummer = string.Empty;
    public string NyStudentPostnummer { get => _nyStudentPostnummer; set { _nyStudentPostnummer = value; OnPropertyChanged(); } }

    private string _nyStudentOrt = string.Empty;
    public string NyStudentOrt { get => _nyStudentOrt; set { _nyStudentOrt = value; OnPropertyChanged(); } }

    // --- Fält för att skapa NY LÄRARE & KOMPETENSOMRÅDE ---
    private string _nyLarareFornamn = string.Empty;
    public string NyLarareFornamn { get => _nyLarareFornamn; set { _nyLarareFornamn = value; OnPropertyChanged(); } }

    private string _nyLarareEfternamn = string.Empty;
    public string NyLarareEfternamn { get => _nyLarareEfternamn; set { _nyLarareEfternamn = value; OnPropertyChanged(); } }

    private string _nyLararePersonnummer = string.Empty;
    public string NyLararePersonnummer { get => _nyLararePersonnummer; set { _nyLararePersonnummer = value; OnPropertyChanged(); } }

    private string _nyLarareTelefon = string.Empty;
    public string NyLarareTelefon { get => _nyLarareTelefon; set { _nyLarareTelefon = value; OnPropertyChanged(); } }

    private string _nyLarareEpost = string.Empty;
    public string NyLarareEpost { get => _nyLarareEpost; set { _nyLarareEpost = value; OnPropertyChanged(); } }

    private string _nyttKompetensomrade = string.Empty;
    public string NyttKompetensomrade { get => _nyttKompetensomrade; set { _nyttKompetensomrade = value; OnPropertyChanged(); } }

    private string? _valdKompetens;
    public string? ValdKompetens { get => _valdKompetens; set { _valdKompetens = value; OnPropertyChanged(); } }

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

    // --- KURSER: Skapa, Uppdatera, Ta bort ---
    public async Task LaggTillKursAsync()
    {
        if (_kursService == null || string.IsNullOrWhiteSpace(NyKursTitel) || string.IsNullOrWhiteSpace(NyKursNummer)) return;

        int.TryParse(NyKursLangd, out int dagar);
        if (dagar <= 0) dagar = 30;

        var nyKurs = new Kurs
        {
            Kursnummer = NyKursNummer.Trim(),
            Title = NyKursTitel.Trim(),
            LangdDagar = dagar,
            StartDatum = DateTime.Now,
            SlutDatum = DateTime.Now.AddDays(dagar)
        };

        if (await _kursService.AddKursAsync(nyKurs))
        {
            NyKursNummer = string.Empty;
            NyKursTitel = string.Empty;
            NyKursLangd = "30";
            await LaddaDataAsync();
        }
    }

    public async Task TaBortKursAsync()
    {
        if (ValdKurs == null || string.IsNullOrEmpty(ValdKurs.Id) || _kursService == null) return;

        if (await _kursService.DeleteKursAsync(ValdKurs.Id))
        {
            Kurser.Remove(ValdKurs);
            ValdKurs = null;
        }
    }

    public async Task UppdateraKursAsync()
    {
        if (ValdKurs == null || string.IsNullOrEmpty(ValdKurs.Id) || _kursService == null) return;

        if (await _kursService.UpdateKursAsync(ValdKurs))
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

    // --- STUDERANDE: Skapa, Uppdatera ---
    public async Task LaggTillStuderandeAsync()
    {
        if (_personService == null || string.IsNullOrWhiteSpace(NyStudentFornamn) || string.IsNullOrWhiteSpace(NyStudentEfternamn)) return;

        var nyStudent = new Studerande
        {
            Fornamn = NyStudentFornamn.Trim(),
            Efternamn = NyStudentEfternamn.Trim(),
            Personnummer = NyStudentPersonnummer.Trim(),
            Telefon = NyStudentTelefon.Trim(),
            Epost = NyStudentEpost.Trim(),
            Adress = NyStudentAdress.Trim(),
            Postnummer = NyStudentPostnummer.Trim(),
            Ort = NyStudentOrt.Trim()
        };

        if (await _personService.AddStuderandeAsync(nyStudent))
        {
            NyStudentFornamn = string.Empty;
            NyStudentEfternamn = string.Empty;
            NyStudentPersonnummer = string.Empty;
            NyStudentTelefon = string.Empty;
            NyStudentEpost = string.Empty;
            NyStudentAdress = string.Empty;
            NyStudentPostnummer = string.Empty;
            NyStudentOrt = string.Empty;
            await LaddaDataAsync();
        }
    }

    public async Task UppdateraStuderandeAsync()
    {
        if (ValdStuderande == null || string.IsNullOrEmpty(ValdStuderande.Id) || _personService == null) return;

        if (await _personService.UpdateStuderandeAsync(ValdStuderande))
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

    // --- LÄRARE & KOMPETENSOMRÅDEN: Skapa, Uppdatera, Kompetenser ---
    public async Task LaggTillLarareAsync()
    {
        if (_personService == null || string.IsNullOrWhiteSpace(NyLarareFornamn) || string.IsNullOrWhiteSpace(NyLarareEfternamn)) return;

        var nyLarare = new Larare
        {
            Fornamn = NyLarareFornamn.Trim(),
            Efternamn = NyLarareEfternamn.Trim(),
            Personnummer = NyLararePersonnummer.Trim(),
            Telefon = NyLarareTelefon.Trim(),
            Epost = NyLarareEpost.Trim()
        };

        if (await _personService.AddLarareAsync(nyLarare))
        {
            NyLarareFornamn = string.Empty;
            NyLarareEfternamn = string.Empty;
            NyLararePersonnummer = string.Empty;
            NyLarareTelefon = string.Empty;
            NyLarareEpost = string.Empty;
            await LaddaDataAsync();
        }
    }

    public async Task UppdateraLarareAsync()
    {
        if (ValdLarare == null || string.IsNullOrEmpty(ValdLarare.Id) || _personService == null) return;

        if (await _personService.UpdateLarareAsync(ValdLarare))
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

    private void UppdateraKompetensLista()
    {
        ValdLarareKompetenser.Clear();
        if (ValdLarare?.Kompetensomraden != null)
        {
            foreach (var k in ValdLarare.Kompetensomraden)
                ValdLarareKompetenser.Add(k);
        }
    }

    public async Task LaggTillKompetensAsync()
    {
        if (ValdLarare == null || string.IsNullOrEmpty(ValdLarare.Id) || string.IsNullOrWhiteSpace(NyttKompetensomrade) || _personService == null) return;

        var kompetens = NyttKompetensomrade.Trim();
        ValdLarare.Kompetensomraden.Add(kompetens);

        if (await _personService.UpdateLarareAsync(ValdLarare))
        {
            ValdLarareKompetenser.Add(kompetens);
            NyttKompetensomrade = string.Empty;
        }
    }

    public async Task TaBortKompetensAsync()
    {
        if (ValdLarare == null || string.IsNullOrEmpty(ValdLarare.Id) || string.IsNullOrEmpty(ValdKompetens) || _personService == null) return;

        ValdLarare.Kompetensomraden.Remove(ValdKompetens);

        if (await _personService.UpdateLarareAsync(ValdLarare))
        {
            ValdLarareKompetenser.Remove(ValdKompetens);
            ValdKompetens = null;
        }
    }
}