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



namespace Przychodnia.Functions
{
    public partial class PatientForm : Window
    {
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
            PESELTextBox.Text = Lists.Patients[index].PESEL.ToString();
            ImieTextBox.Text = Lists.Patients[index].Imie.ToString();
            NazwiskoTextBox.Text = Lists.Patients[index].Nazwisko.ToString();
            PlecComboBox.Text = Lists.Patients[index].Plec.ToString();
            NumerKontaktowyTextBox.Text = Lists.Patients[index].Numer_kontaktowy.ToString();
            WiekTextBox.Text = Lists.Patients[index].Wiek.ToString();
            AdresTextBox.Text = Lists.Patients[index].Adres.ToString();
            DzienUrComboBox.SelectedItem = Lists.Patients[index].Data_urodzenia.Substring(0, 2).ToString();
            MiesiacUrComboBox.SelectedItem = Lists.Patients[index].Data_urodzenia.Substring(3, 2).ToString();
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

            for (int i = 0; i < 32; i++)
                DzienUrComboBox.Items.Add(i);
            for (int i = 1920; i < 2021; i++)
                RokUrComboBox.Items.Add(i);

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

        private void SavePatientButtonClick(object sender, RoutedEventArgs e)
        {
            
            if (PESELTextBox.Text == "")
                MessageBox.Show("Pole PESEL jest puste!");
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









            //Dalsze warunki
            else
            {
                if (FunctionName.Content == "Dodaj pacjenta")
                {
                    //AddPatient()
                }
                else if (FunctionName.Content == "Edytuj pacjenta")
                {
                    //UpdatePatient()
                }
            }
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
        private void ImieTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NazwiskoTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void AdresTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void PESELTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ImieTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WiekTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void AdresTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NumerKontaktowyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
    }
}
