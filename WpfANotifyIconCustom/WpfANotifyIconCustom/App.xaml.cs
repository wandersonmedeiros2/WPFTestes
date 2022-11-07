using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private ContextMenu _contextMenu;

        private void CreateNotifyIcon()
        {
            _notifyIcon = new Forms.NotifyIcon();
            _notifyIcon.Text = "AppTest";          
            _notifyIcon.Icon = new System.Drawing.Icon("xamarin.ico");
            _notifyIcon.Visible = true;
            CreateContexMenu();

        }

        private void CreateContexMenu()
        {
            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            _notifyIcon.MouseClick -= NotifyIcomMouseClick;
            _notifyIcon.MouseClick += NotifyIcomMouseClick;

            _contextMenu = new ContextMenu();           
            _contextMenu.Placement = PlacementMode.MousePoint;
            _contextMenu.Items.Add("Option 1");
            _contextMenu.Items.Add("Option 2");
            _contextMenu.Items.Add("Option 3");
        }

        private void NotifyIcomMouseClick(object sender, Forms.MouseEventArgs e)
        {
            switch (e.Button)
            {
                case Forms.MouseButtons.Right:
                    _contextMenu.IsOpen = true;
                    break;
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            CreateNotifyIcon();            


            AppStatusObservable.Instance.Subscribe(new StatusAppObserver(_notifyIcon));
            base.OnStartup(e);
        }        
    }
}
