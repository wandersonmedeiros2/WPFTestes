using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfANotifyIconCustom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RefreshAppstatus();
        }

        public void RefreshAppstatus()
        {
            lbStatus.Text = $"Status of App: {UtilsLib.AppStatusHandler.Instance.Status.ToString()}";
        }

        private void btOnline_Click(object sender, RoutedEventArgs e)
        {
            UtilsLib.AppStatusHandler.Instance.Status = UtilsLib.AppStatus.Online;
            RefreshAppstatus();
        }

        private void btOfline_Click(object sender, RoutedEventArgs e)
        {
            UtilsLib.AppStatusHandler.Instance.Status = UtilsLib.AppStatus.Offline;
            RefreshAppstatus();
        }

        private void btDisconected_Click(object sender, RoutedEventArgs e)
        {
            UtilsLib.AppStatusHandler.Instance.Status = UtilsLib.AppStatus.Disconected;
            RefreshAppstatus();
        }
    }
}
