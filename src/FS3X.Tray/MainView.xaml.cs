using System.Windows;

namespace FS3X.Tray
{

    public partial class MainView : Window
    {
        bool _supressClosing = true;

        public MainView()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            _supressClosing = false;
            this.Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            this.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_supressClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
