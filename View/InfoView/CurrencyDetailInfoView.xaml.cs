using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoinCheck.View.InfoView
{
    /// <summary>
    /// Interaction logic for CurrencyDetailInfoView.xaml
    /// </summary>
    public partial class CurrencyDetailInfoView : UserControl
    {
        public CurrencyDetailInfoView()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string uri = e.Uri.ToString();
            Process.Start(new ProcessStartInfo(uri) { UseShellExecute = true });
        }
    }
}
