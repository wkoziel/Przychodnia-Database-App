using Przychodnia.DAL.Encje;
using System;
using System.Windows;
using System.Windows.Controls;
namespace Przychodnia.Functions
{

    public partial class AppointmentForm : Window
    {
        public AppointmentForm()
        {
            InitializeComponent();
            ComboBoxFill();
        }

        public AppointmentForm(int index)
        {
            InitializeComponent();
            ComboBoxFill();
            ID_wizytyTextBox.Text = Lists.Appointments[index].ID_wizyty.ToString();
            PESEL_Combobox.SelectedItem = Lists.Appointments[index].PESEL.ToString();
            NrSaliComboBox.SelectedItem = Lists.Appointments[index].Numer_sali;
            IdLekarzaComboBox.SelectedItem = Lists.Appointments[index].ID_lekarza;
            DataWizytyCombobox.SelectedItem = Lists.Appointments[index].Data_wizyty.ToString(); //Tu trzeba poprawić bo jakaś dziwna konwersja jest
            GodzWizytyComboBox.SelectedItem = Lists.Appointments[index].Godzina_wizyty.ToString();
            RodzajWizytyComboBox.SelectedItem = Lists.Appointments[index].Rodzaj_wizyty.ToString();
            OpisTextBox.Text = Lists.Appointments[index].Opis_dolegliwosci.ToString();
            ChorobaTextBox.Text = Lists.Appointments[index].Choroba.ToString();
            LeczenieTextBox.Text = Lists.Appointments[index].Leczenie.ToString();
            ZwolnienieTextBox.Text = Lists.Appointments[index].Zwolnienie.ToString();

        }
        private void XButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxFill()
        {
            foreach (var item in Lists.Patients)
                PESEL_Combobox.Items.Add(item.PESEL);

            foreach (var item in Lists.Rooms)
                NrSaliComboBox.Items.Add(item.Numer_sali);
            
            foreach (var item in Lists.Doctors)
                IdLekarzaComboBox.Items.Add(item.ID_lekarza);

            GodzWizytyComboBox.Items.Add("08:00:00");
            GodzWizytyComboBox.Items.Add("08:30:00");
            GodzWizytyComboBox.Items.Add("09:00:00");
            GodzWizytyComboBox.Items.Add("09:30:00");
            GodzWizytyComboBox.Items.Add("10:00:00");
            GodzWizytyComboBox.Items.Add("10:30:00");
            GodzWizytyComboBox.Items.Add("11:00:00");
            GodzWizytyComboBox.Items.Add("11:30:00");
            GodzWizytyComboBox.Items.Add("12:00:00");
            GodzWizytyComboBox.Items.Add("12:30:00");
            GodzWizytyComboBox.Items.Add("13:00:00");
            GodzWizytyComboBox.Items.Add("13:30:00");
            GodzWizytyComboBox.Items.Add("14:00:00");
            GodzWizytyComboBox.Items.Add("14:30:00");
            GodzWizytyComboBox.Items.Add("15:00:00");
            GodzWizytyComboBox.Items.Add("15:30:00");
            GodzWizytyComboBox.Items.Add("16:00:00");
            GodzWizytyComboBox.Items.Add("16:30:00");
            GodzWizytyComboBox.Items.Add("17:00:00");

            RodzajWizytyComboBox.Items.Add("Badanie");
            RodzajWizytyComboBox.Items.Add("Zabieg");
            RodzajWizytyComboBox.Items.Add("Kontrola");
        }

    }
}
