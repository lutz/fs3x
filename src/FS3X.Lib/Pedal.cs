using System.IO.Ports;

namespace FS3X.Lib
{
    public class Pedal
    {
        #region Fields

        SerialPort _serialPort;
        string _portName;

        #endregion

        #region EventHandler

        public delegate void PedalButtonChangedHandler(object sender, PedalButtonEventArgs args);

        public event PedalButtonChangedHandler PedalButtonChanged;

        protected void OnPedalButtonChanged(PedalButton button, PedalButtonStatus status)
        {
            PedalButtonChanged?.Invoke(this, new PedalButtonEventArgs(button, status));
        }

        #endregion

        #region Constructors

        public Pedal(string portName)
        {
            _portName = portName;
        }


        #region Events

        void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = _serialPort.ReadLine();
            if (data.TryParse(out int number))
            {
                switch (number)
                {
                    case 0:
                        OnPedalButtonChanged(PedalButton.Mode, PedalButtonStatus.Released);
                        break;
                    case 1:
                        OnPedalButtonChanged(PedalButton.Mode, PedalButtonStatus.Pressed);
                        break;
                    case 4:
                        OnPedalButtonChanged(PedalButton.Down, PedalButtonStatus.Released);
                        break;
                    case 5:
                        OnPedalButtonChanged(PedalButton.Down, PedalButtonStatus.Pressed);
                        break;
                    case 7:
                        OnPedalButtonChanged(PedalButton.Up, PedalButtonStatus.Released);
                        break;
                    case 8:
                        OnPedalButtonChanged(PedalButton.Up, PedalButtonStatus.Pressed);
                        break;

                    default:
                        OnPedalButtonChanged(PedalButton.Undefined, PedalButtonStatus.Undefined);
                        break;
                }
            }

        }

        #endregion

        #region Properties

        public bool IsSwitchedOn => _serialPort != null;

        #endregion

        #region Methods

        public void SwitchOn()
        {
            if (_serialPort != null) return;
            _serialPort = new SerialPort(_portName)
            {
                BaudRate = 9600
            };
            _serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                _serialPort.Open();
            }
            catch (System.Exception inner)
            {
                SwitchOff();
                throw new PedalException("Open SerialPort throws an exception", inner);
            }


        }

        public void SwitchOff()
        {
            if (_serialPort == null) return;
            _serialPort.DataReceived -= SerialPort_DataReceived;
            _serialPort.Close();
            _serialPort.Dispose();
            _serialPort = null;
        }

        #endregion

        #endregion
    }
}
