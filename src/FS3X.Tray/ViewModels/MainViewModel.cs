using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using System.IO.Ports;
using FS3X.Lib;

namespace FS3X.Tray
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        readonly Pedal _pedal;
        readonly IDialogService _dialogService;

        #endregion

        #region Constructors

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            PortModels = SerialPort.GetPortNames().Select(name => new PortModel(name)).ToList();
            ActivateCommand = new RelayCommand(ActivateCommandExecute);
            _pedal = new Pedal();
            _pedal.PedalButtonChanged += Pedal_PedalButtonChanged;
        }


        #endregion

        #region Commands

        public ICommand ActivateCommand { get; }

        void ActivateCommandExecute(object sender)
        {
            if (_pedal != null && _pedal.IsConnected)
            {
                PortModels.ForEach(pm => pm.Connected = false);
                _pedal.Disconnect();
                IsConnected = false;
            }

            try
            {
                _pedal.Connect(sender.ToString());

                var model = PortModels.FirstOrDefault(pm => pm.Name.Equals(sender.ToString(), StringComparison.OrdinalIgnoreCase));
                if (model != null) model.Connected = true;

                IsConnected = true;
            }
            catch (PedalException ex)
            {
                _dialogService.ShowError(ex.InnerException.Message);
                PortModels.ForEach(pm => pm.Connected = false);
                IsConnected = false;
            }
        }

        #endregion

        #region Properties

        public List<PortModel> PortModels { get; }

        bool _isPressed;
        public bool IsPressed
        {
            get { return _isPressed; }
            set { SetAndFirePropertyChanged(ref _isPressed, value); }
        }

        bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set { SetAndFirePropertyChanged(ref _isConnected, value); }
        }

        #endregion

        #region Events

        void Pedal_PedalButtonChanged(object sender, PedalButtonEventArgs args)
        {
            IsPressed = args.Status == PedalButtonStatus.Pressed;
        }

        #endregion
    }
}
