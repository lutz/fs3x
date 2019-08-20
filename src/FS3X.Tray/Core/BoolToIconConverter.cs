using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace FS3X.Tray
{
    public class BoolToIconConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            

            if (values.Length != 2) return new BitmapImage(new Uri(DisconnectedIconPath, UriKind.RelativeOrAbsolute));
            var isConnected = values[0] as bool?;
            var isPressed = values[1] as bool?;

            if (!isConnected.GetValueOrDefault(false)) return new BitmapImage(new Uri(DisconnectedIconPath, UriKind.RelativeOrAbsolute));
            return isPressed.GetValueOrDefault(false) ? new BitmapImage(new Uri(PressedStatusIconPath, UriKind.RelativeOrAbsolute)) : new BitmapImage(new Uri(ReleasedStatusIconPath, UriKind.RelativeOrAbsolute));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public string DisconnectedIconPath { get; set; }

        public string PressedStatusIconPath { get; set; }

        public string ReleasedStatusIconPath { get; set; }
    }
}
