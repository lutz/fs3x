using System.Windows;

namespace FS3X.Tray
{
    public partial class App : Application
    {
        void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainView = new MainView();
            mainView.DataContext = new MainViewModel(new WindowDialogService(mainView));
            mainView.Closed += (s, args) => ((MainViewModel)mainView.DataContext).Dispose();
            mainView.Hide();
        }
    }
}
