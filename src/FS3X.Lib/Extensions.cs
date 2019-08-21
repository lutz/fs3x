using System;
using System.ComponentModel;
using System.Windows.Threading;
using System.Linq;
using static FS3X.Lib.Pedal;

namespace FS3X.Lib
{
    internal static class Extensions
    {
        public static bool TryParse(this string @string, out int @number)
        {
            number = -1;

            if (string.IsNullOrEmpty(@string)) return false;

            @string = @string.Trim();

            if (int.TryParse(@string, out int result))
            {
                number = result;
                return true;
            }

            return false;
        }

        public static void ThreadAwareRaise(this PedalButtonChangedHandler customEvent, object sender, PedalButtonEventArgs e)
        {
            foreach (var d in customEvent.GetInvocationList().OfType<PedalButtonChangedHandler>())
                switch (d.Target)
                {
                    case DispatcherObject dispatchTartget:
                        dispatchTartget.Dispatcher.BeginInvoke(d, sender, e);
                        break;
                    case ISynchronizeInvoke syncTarget when syncTarget.InvokeRequired:
                        syncTarget.BeginInvoke(d, new[] { sender, e });
                        break;
                    default:
                        d.Invoke(sender, e);
                        break;
                }
        }
    }
}
