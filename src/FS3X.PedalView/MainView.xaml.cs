using System;
using System.Windows;
using System.Windows.Media;
using FS3X.Lib;

namespace FS3X.PedalView
{
    public partial class MainView : Window
    {
        #region Fields

        Pedal _pedal;

        #endregion

        #region Constructors

        public MainView()
        {
            InitializeComponent();
            _pedal = new Pedal("COM4");
            _pedal.PedalButtonChanged += Pedal_PedalButtonChanged;
            _pedal.SwitchOn();
        }

        #endregion

        #region Events

        void Pedal_PedalButtonChanged(object sender, PedalButtonEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                switch (args.Button)
                {
                    case PedalButton.Mode:
                        modeButton.Fill = GetBrushByPedalButtonStatus(args.Status);
                        break;
                    case PedalButton.Down:
                        modeButton.Fill = GetBrushByPedalButtonStatus(args.Status);
                        break;
                    case PedalButton.Up:
                        modeButton.Fill = GetBrushByPedalButtonStatus(args.Status);
                        break;
                }
            });
        }

        void Window_Closed(object sender, EventArgs e)
        {
            _pedal.SwitchOff();
        }

        #endregion

        #region Methods

        SolidColorBrush GetBrushByPedalButtonStatus(PedalButtonStatus status)
        {
            switch (status)
            {
                case PedalButtonStatus.Pressed:
                    return Brushes.DarkGreen;
                case PedalButtonStatus.Released:
                    return Brushes.Black;
                default:
                    return Brushes.Black;
            }
        }

        #endregion
    }
}
