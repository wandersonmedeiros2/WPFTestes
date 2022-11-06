using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilsLib;

namespace WpfANotifyIconCustom.Observers
{
    public class StatusAppObserver : IObserver<AppStatusObservable>
    {
        private readonly NotifyIcon _notifyIcon;
        private AppStatusObservable _appCurrentStatus;

        public StatusAppObserver(NotifyIcon notifyIcon)
        {
            _notifyIcon = notifyIcon;
        }

        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(AppStatusObservable value)
        {
            _appCurrentStatus = value;
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            string baseText = "AppTest";
            _notifyIcon.Text = $"{baseText} - {_appCurrentStatus.AppCurrentStatus.ToString()}";
        }
    }
}
