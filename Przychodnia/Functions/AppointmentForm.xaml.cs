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
            ComboBoxFill();

        }

        private void XButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxFill()
        {
            for (int i = 0; i < 32; i++)
                DzienWComboBox.Items.Add(i);
            for (int i = 1920; i < 2021; i++)
                RokWComboBox.Items.Add(i);

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

            MiesiacWComboBox.Items.Add("Styczeń");
            MiesiacWComboBox.Items.Add("Luty");
            MiesiacWComboBox.Items.Add("Marzec");
            MiesiacWComboBox.Items.Add("Kwiecień");
            MiesiacWComboBox.Items.Add("Maj");
            MiesiacWComboBox.Items.Add("Czerwiec");
            MiesiacWComboBox.Items.Add("Lipiec");
            MiesiacWComboBox.Items.Add("Sierpień");
            MiesiacWComboBox.Items.Add("Wrzesień");
            MiesiacWComboBox.Items.Add("Październik");
            MiesiacWComboBox.Items.Add("Listopad");
            MiesiacWComboBox.Items.Add("Grudzień");
        }

        private void DzienUrComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void WiekComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GodzWizytyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
