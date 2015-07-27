using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Input;

namespace Utilities
{
    public delegate void OnScannedHandler();

    public class Scanner
    {
        private readonly StringBuilder _scanData = new StringBuilder();
        private readonly KeyConverter _scanKeyConverter = new KeyConverter();

        public string ScannedString => _scanData.ToString();

        public event OnScannedHandler Scanned;

        public void BeginScan(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Tab)
            {
                RaiseScannedEvent();
                _scanData.Clear();
            }
            else if( !isIgnorableKey(e.Key) )
            {
                _scanData.Append(_scanKeyConverter.ConvertToString(e.Key));
            }
        }

        private static bool isIgnorableKey(Key key) => isKeyCtrl(key) || isKeyShift(key);

        private static bool isKeyShift(Key key) => key == Key.LeftShift || key == Key.RightShift;

        private static bool isKeyCtrl(Key key) => key == Key.LeftCtrl || key == Key.RightCtrl;

        private void RaiseScannedEvent() => Scanned?.Invoke(); 
    }
}