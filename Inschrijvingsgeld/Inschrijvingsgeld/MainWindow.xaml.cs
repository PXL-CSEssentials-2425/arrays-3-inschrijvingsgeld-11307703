using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inschrijvingsgeld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _opleidingen = { "Programmeren", "Netwerkbeheer", "Internet of Things", "Digitale vormgever", "Drone opleiding" };
        private double[] _inschrijvingsGeld = {920.80, 920.80, 520.80, 750.80, 520.80};
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            foreach (var opleiding in _opleidingen)
            {           
                ComboBoxItem item = new ComboBoxItem();
                item.Content = opleiding;
                cmbOpleiding.Items.Add(item);
                
            }
        }

        private double GetReduction()
        {
            double reduction = 0;
            if (rbHogerSecundair.IsChecked == true)
            {
                return reduction = 0.3;
            }
            else if (rbGraduaat.IsChecked == true)
            {
               return reduction = 0.2;
            }
            else if (rbMaster.IsChecked == true)
            {
               return reduction = 1.1;
            }
            return reduction =0;
        }

        private double IsStudentWorking()
        {
            double reduction = 0;
            if (chkWerkzoekend.IsChecked == true)
            {
                return reduction = 0.5;
            }
            return reduction = 0;
        }
        private void btnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            string name = txtNaam.Text;
            double inschrijvingsGeld = _inschrijvingsGeld[cmbOpleiding.SelectedIndex];
            double reduction = IsStudentWorking();
            double reduction2 = GetReduction();
            double subTotal = inschrijvingsGeld * reduction;
            double subTotal2 = subTotal * reduction2;
            double totaal = inschrijvingsGeld - subTotal - subTotal2;
            txtResultaat.Text = $" Inschrijvingsbedrag voor: {name}\nBasisbedrag: {inschrijvingsGeld:c}\nTebetalen: {totaal:c}";

        }
    }
}