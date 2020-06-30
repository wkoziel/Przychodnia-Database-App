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
using System.Windows.Shapes;

namespace Przychodnia.Functions
{
    /// <summary>
    /// Interaction logic for PatientForm.xaml
    /// </summary>
    public partial class PatientForm : Window
    {
        public PatientForm()
        {
            InitializeComponent();
            ComboBoxFill();
        }

        public PatientForm(int index)
        {
            InitializeComponent();
            ComboBoxFill();
        }

        private void XButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxFill()
        {
            PlecComboBox.Items.Add("Kobieta");
            PlecComboBox.Items.Add("Mężczyzna");

            for (int i = 0; i < 32; i++)
                DzienUrComboBox.Items.Add(i);
            for (int i = 1920; i < 2021; i++)
                RokUrComboBox.Items.Add(i);

            for (int i = 0; i < 130; i++)
                WiekComboBox.Items.Add(i);

            MiesiacUrComboBox.Items.Add("Styczeń");
            MiesiacUrComboBox.Items.Add("Luty");
            MiesiacUrComboBox.Items.Add("Marzec");
            MiesiacUrComboBox.Items.Add("Kwiecień");
            MiesiacUrComboBox.Items.Add("Maj");
            MiesiacUrComboBox.Items.Add("Czerwiec");
            MiesiacUrComboBox.Items.Add("Lipiec");
            MiesiacUrComboBox.Items.Add("Sierpień");
            MiesiacUrComboBox.Items.Add("Wrzesień");
            MiesiacUrComboBox.Items.Add("Październik");
            MiesiacUrComboBox.Items.Add("Listopad");
            MiesiacUrComboBox.Items.Add("Grudzień");
        }
    }
}
