using System.Windows;

namespace FS3X.Tray
{

    public partial class MainView : Window
    {
        #region Fields

        bool _supressClosing = true;

        #endregion

        #region Constructors

        public MainView()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            _supressClosing = false;
            this.Close();
        }


        private void Hide_Click(object sender, RoutedEventArgs e)
        {
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

        #endregion
    }
}
