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
using System.Text.RegularExpressions;
using Przychodnia.DAL.Repozytoria;
using Przychodnia.AllTabs;
using Przychodnia.Tabs;

namespace Przychodnia.Functions
{
    public partial class PatientForm : Window
    {
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;
        public PatientForm()
        {
            InitializeComponent();
            FunctionName.Content = "Dodaj pacjenta";
            ComboBoxFill();
        }

        public PatientForm(int index)
        {
            InitializeComponent();
            FunctionName.Content = "Edytuj pacjenta";
            ComboBoxFill();
            PESELTextBox.IsReadOnly = true;
            PESELTextBox.Text = Lists.Patients[index].PESEL.ToString();
            ImieTextBox.Text = Lists.Patients[index].Imie.ToString();
            NazwiskoTextBox.Text = Lists.Patients[index].Nazwisko.ToString();
            PlecComboBox.Text = Lists.Patients[index].Plec.ToString();
            NumerKontaktowyTextBox.Text = Lists.Patients[index].Numer_kontaktowy.ToString();
            WiekTextBox.Text = Lists.Patients[index].Wiek.ToString();
            AdresTextBox.Text = Lists.Patients[index].Adres.ToString();
            DzienUrComboBox.SelectedItem = Lists.Patients[index].Data_urodzenia.Substring(0, 2).ToString();
            MiesiacUrComboBox.SelectedIndex = (int.Parse(Lists.Patients[index].Data_urodzenia.Substring(3, 2))-1);
            RokUrComboBox.SelectedItem = Lists.Patients[index].Data_urodzenia.Substring(6, 4).ToString();
        }

        private void XButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxFill()
        {
            PlecComboBox.Items.Add("Kobieta");
            PlecComboBox.Items.Add("Mężczyzna");

            for (int i = 1; i < 10; i++)
                DzienUrComboBox.Items.Add("0"+i.ToString());
            for (int i = 10; i < 32; i++)
                DzienUrComboBox.Items.Add(i.ToString());
            for (int i = 1920; i < 2021; i++)
                RokUrComboBox.Items.Add(i.ToString());

            MiesiacUrComboBox.Items.Add("Sty");
            MiesiacUrComboBox.Items.Add("Lut");
            MiesiacUrComboBox.Items.Add("Marz");
            MiesiacUrComboBox.Items.Add("Kwi");
            MiesiacUrComboBox.Items.Add("Maj");
            MiesiacUrComboBox.Items.Add("Czer");
            MiesiacUrComboBox.Items.Add("Lip");
            MiesiacUrComboBox.Items.Add("Sie");
            MiesiacUrComboBox.Items.Add("Wrze");
            MiesiacUrComboBox.Items.Add("Paź");
            MiesiacUrComboBox.Items.Add("Lis");
            MiesiacUrComboBox.Items.Add("Gru");
        }

        private void SavePatientButtonClick(object sender, RoutedEventArgs e)
        {
            if (PESELTextBox.Text == "")
                MessageBox.Show("Pole PESEL jest puste!");
            else if(ChceckPesel(PESELTextBox.Text, ImieTextBox.Text) == true && FunctionName.Content.ToString() != "Edytuj pacjenta")
                MessageBox.Show("Podany PESEL istnieje już w bazie");
            else if (PESELTextBox.Text.Length < 11)
                MessageBox.Show("Pole PESEL musi zawierać 11 cyfr!");
            else if (ImieTextBox.Text == "")
                MessageBox.Show("Pole Imię jest puste!");
            else if (NazwiskoTextBox.Text == "")
                MessageBox.Show("Pole Nazwisko jest puste!");
            else if (WiekTextBox.Text == "")
                MessageBox.Show("Pole wiek jest puste!");
            else if (AdresTextBox.Text == "")
                MessageBox.Show("Pole Adres jest puste!");
            else if (NumerKontaktowyTextBox.Text == "")
                MessageBox.Show("Pole Numer kontaktowy jest puste!");
            else if (PlecComboBox.SelectedIndex == -1)
                MessageBox.Show("Pole Płeć nie zostało wybrane!");
            else if (DzienUrComboBox.SelectedIndex == -1)
                MessageBox.Show("Pole Dzień nie zostało wybrane!");
            else if (MiesiacUrComboBox.SelectedIndex == -1)
                MessageBox.Show("Pole Miesiac nie zostało wybrane!");
            else if (RokUrComboBox.SelectedIndex == -1)
                MessageBox.Show("Pole Rok nie zostało wybrane!");
            else
            {
                if (FunctionName.Content.ToString() == "Dodaj pacjenta")
                {
                    PatientRepo.AddNewPatient(PESELTextBox.Text, ImieTextBox.Text, NazwiskoTextBox.Text,
                        PlecComboBox.SelectedItem.ToString(), RokUrComboBox.SelectedItem.ToString(), (MiesiacUrComboBox.SelectedIndex + 1).ToString(),
                        DzienUrComboBox.SelectedItem.ToString(), WiekTextBox.Text.ToString(),AdresTextBox.Text.ToString(), NumerKontaktowyTextBox.Text.ToString());

                    DataChangedEventHandler handler = DataChanged;
                    if (handler != null)
                        handler(this, new EventArgs());

                    this.Close();
                }
                else if (FunctionName.Content.ToString() == "Edytuj pacjenta")
                {
                    PatientRepo.UpdatePatient(PESELTextBox.Text, ImieTextBox.Text, NazwiskoTextBox.Text,
                        PlecComboBox.SelectedItem.ToString(), RokUrComboBox.SelectedItem.ToString(), (MiesiacUrComboBox.SelectedIndex + 1).ToString(),
                        DzienUrComboBox.SelectedItem.ToString(), WiekTextBox.Text.ToString(), AdresTextBox.Text.ToString(), NumerKontaktowyTextBox.Text.ToString());

                    DataChangedEventHandler handler = DataChanged;
                    if (handler != null)
                        handler(this, new EventArgs());

                    this.Close();
                }
            }
        }

        bool ChceckPesel(string pesel, string imie)
        {
            foreach (var item in Lists.Patients)
                if (item.PESEL == pesel && item.Imie != imie)
                    return true;
            return false;
        }

        private void PESELTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { 
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
        }

        private void NumerKontaktowyTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void WiekTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
