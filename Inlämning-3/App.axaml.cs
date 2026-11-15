using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using WestCoastEducation.Desktop.Services;
using WestCoastEducation.Desktop.ViewModels;
using WestCoastEducation.Desktop.Views;

namespace WestCoastEducation.Desktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var settings = RestDbSettings.Load();
            var kursService = new RestDbService(settings);
            var personService = new RestDbService(settings);

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(kursService, personService)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}