using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FS3X.Tray
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetAndFirePropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (!property.Equals(value))
            {
                property = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}