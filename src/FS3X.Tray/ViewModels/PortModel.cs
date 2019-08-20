namespace FS3X.Tray
{
    public class PortModel : BaseViewModel
    {
        public PortModel(string name)
        {
            Name = name;
        }
        public string Name { get; }

        bool _connected;
        public bool Connected { get => _connected; set => SetAndFirePropertyChanged(ref _connected, value); }
    }
}