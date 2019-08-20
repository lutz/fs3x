using System.Windows;

namespace FS3X.Tray
{
    internal class WindowDialogService : IDialogService
    {
        Window _window;

        public WindowDialogService(Window window)
        {
            _window = window;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(_window, message, _window.Title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
