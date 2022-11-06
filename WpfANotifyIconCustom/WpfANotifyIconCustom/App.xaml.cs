using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UtilsLib;
using WpfANotifyIconCustom.Observers;
using Forms = System.Windows.Forms;

namespace WpfANotifyIconCustom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Forms.NotifyIcon _notifyIcon;

        private void CreateNotifyIcon()
        {
            _notifyIcon = new Forms.NotifyIcon();
            _notifyIcon.Text = "AppTest";          
            _notifyIcon.Icon = new System.Drawing.Icon("xamarin.ico");
            _notifyIcon.Visible = true;

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            CreateNotifyIcon();
            
            AppStatusObservable.Instance.Subscribe(new StatusAppObserver(_notifyIcon));
            base.OnStartup(e);
        }

    }
}
