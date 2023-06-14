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

namespace CoinCheck.View
{
    /// <summary>
    /// Interaction logic for ConvertCurrencyView.xaml
    /// </summary>
    public partial class ConvertCurrencyView : UserControl
    {
        public ConvertCurrencyView()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text.Insert(textBox.CaretIndex, e.Text);

            if (!IsNumberWithComma(newText) || newText.StartsWith(","))
            {
                e.Handled = true;
            }
        }

        private bool IsNumberWithComma(string text)
        {
            return double.TryParse(text, out _);
        }

    }
}
