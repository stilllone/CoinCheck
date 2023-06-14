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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoinCheck.View.UIElements
{
    /// <summary>
    /// Interaction logic for UIStackTextViewer.xaml
    /// </summary>
    public partial class UIStackTextViewer : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
        DependencyProperty.Register("LabelText", typeof(string), typeof(UIStackTextViewer), new PropertyMetadata(null));

        public static readonly DependencyProperty TextBoxTextProperty =
            DependencyProperty.Register("TBText", typeof(string), typeof(UIStackTextViewer), new PropertyMetadata(null));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public string TBText
        {
            get { return (string)GetValue(TextBoxTextProperty); }
            set { SetValue(TextBoxTextProperty, value); }
        }
        public UIStackTextViewer()
        {
            InitializeComponent();
        }
    }
}
