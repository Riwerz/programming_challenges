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
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TemperatureConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:,[0-9]*)?$");
            e.Handled = !(regex.IsMatch(e.Text) && !(e.Text == "," && ((TextBox)sender).Text.Contains(e.Text)));
        }


        private void convertButton_Click(object sender, RoutedEventArgs e)
            {
                if(tempScales_From.SelectedItem == null || tempScales_To.SelectedItem == null)
                {
                    MessageBox.Show("Please specify temperature scales!", "Validation Error");
                    return;
                }
                string scalesCombination = tempScales_From.Text + tempScales_To.Text;

                switch (scalesCombination)
                {
                    case "CC":
                    case "FF":
                    case "KK":
                        value_To.Text = value_From.Text;
                        break;
                    case "CF":
                        value_To.Text = (9.0 * Double.Parse(value_From.Text) / 5.0 + 32.0).ToString("0.00");
                        break;
                    case "CK":
                        value_To.Text = (273.0 + Double.Parse(value_From.Text)).ToString("0.00");
                        break;
                    case "FC":
                        value_To.Text = (5.0 * (Double.Parse(value_From.Text) - 32.0) / 9.0).ToString("0.00");
                        break;
                    case "FK":
                        value_To.Text = (5.0 * (Double.Parse(value_From.Text) - 32.0) / 9.0 + 273.15).ToString("0.00");
                        break;
                    case "KC":
                        value_To.Text = (Double.Parse(value_From.Text) - 273.0).ToString("0.00");
                        break;
                    case "KF":
                        value_To.Text = (9.0 * (Double.Parse(value_From.Text) - 273.15) / 5.0 + 32).ToString("0.00");
                        break;
                }
            }
        }
}
