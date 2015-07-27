using System.Text;
using System.Windows.Input;

namespace Utilities
{
    public delegate void OnScannedHandler();

    public class Scanner
    {
        private readonly StringBuilder _scanData = new StringBuilder();
        private readonly KeyConverter _scanKeyConverter = new KeyConverter();

        public string ScannedString
        {
            get { return _scanData.ToString(); }
        }

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

        private bool isIgnorableKey(Key key)
        {
            return isKeyCtrl(key) || isKeyShift(key);
        }

        private bool isKeyShift(Key key)
        {
            return key == Key.LeftShift || key == Key.RightShift;
        }

        private bool isKeyCtrl(Key key)
        {
            return key == Key.LeftCtrl || key == Key.RightCtrl;
        }

        private void RaiseScannedEvent()
        {
            Scanned?.Invoke();
        }
    }
}