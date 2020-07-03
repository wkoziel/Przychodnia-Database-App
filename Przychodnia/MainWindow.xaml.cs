using Przychodnia.AllTabs;
using Przychodnia.DAL.Repozytoria;
using Przychodnia.Functions;
using Przychodnia.Tabs;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Przychodnia
{
    public partial class MainWindow : Window
    {
        public string Login { get; set; }
        public bool IfDoctor { get; set; }

        //Konstruktor
        public MainWindow(bool ifdoc, string login)
        {
            InitializeComponent();
            FillTabsComboBox();
            IfDoctor = ifdoc;
            Login = login;
            if (ifdoc) 
            { 
                LoginAs.Content += "lekarz";
                AddContent.IsEnabled = false;
                EditContent.IsEnabled = true;
                DeleteContent.IsEnabled = false;
            } else LoginAs.Content += "recepcjonista";
        }


        //Wypełnia combobox
        void FillTabsComboBox()
        {
            TabsComboBox.Items.Add("Wizyty");
            TabsComboBox.Items.Add("Pacjenci");
            TabsComboBox.Items.Add("Lekarze");
            TabsComboBox.Items.Add("Sale");
            TabsComboBox.Items.Add("Poradnie");
            TabsComboBox.Items.Refresh();
        }


        //Wyświetla tabele odpowiednio do wyboru z combobox'a
        private void ChangeTableComboBox(object sender, SelectionChangedEventArgs e)
        {
            int choice = TabsComboBox.SelectedIndex;
            if (choice == 0 & IfDoctor == false)
            {
                AddContent.IsEnabled = true;
                EditContent.IsEnabled = true;
                DeleteContent.IsEnabled = true;
                TodayAppointmentsButton.IsEnabled = true;
                PatientAppointmentsButton.IsEnabled = false;
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new AppointmentTab(1));
                TodayAppointmentsButton.Content = "Dzisiejsze wizyty";
            }
            else if (choice == 0 & IfDoctor == true)
            {
                AddContent.IsEnabled = false;
                EditContent.IsEnabled = true;
                DeleteContent.IsEnabled = false;
                TodayAppointmentsButton.IsEnabled = true;
                PatientAppointmentsButton.IsEnabled = false;
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new AppointmentTab(1));
                TodayAppointmentsButton.Content = "Dzisiejsze wizyty";
            }
            else if(choice == 1 & IfDoctor == false)
            {
                AddContent.IsEnabled = true;
                EditContent.IsEnabled = true;
                DeleteContent.IsEnabled = true;
                TodayAppointmentsButton.IsEnabled = false;
                PatientAppointmentsButton.IsEnabled = true;
                PatientAppointmentsButton.Content = "Wizyty Pacjenta";
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new PatientTab());
            }
            else if (choice == 1 & IfDoctor == true)
            {
                AddContent.IsEnabled = false;
                EditContent.IsEnabled = false;
                DeleteContent.IsEnabled = false;
                TodayAppointmentsButton.IsEnabled = false;
                PatientAppointmentsButton.IsEnabled = true;
                PatientAppointmentsButton.Content = "Wizyty Pacjenta";
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new PatientTab());
            }
            else if (choice == 2)
            {
                AddContent.IsEnabled = false;
                EditContent.IsEnabled = false;
                DeleteContent.IsEnabled = false;
                TodayAppointmentsButton.IsEnabled = false;
                PatientAppointmentsButton.IsEnabled = true;
                PatientAppointmentsButton.Content = "Wizyty Lekarza";
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new DoctorTab());
            }
            else if (choice == 3)
            {
                AddContent.IsEnabled = false;
                EditContent.IsEnabled = false;
                DeleteContent.IsEnabled = false;
                TodayAppointmentsButton.IsEnabled = false;
                PatientAppointmentsButton.IsEnabled = false;
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new RoomTab());
            }
            else if (choice == 4)
            {
                AddContent.IsEnabled = false;
                EditContent.IsEnabled = false;
                DeleteContent.IsEnabled = false;
                TodayAppointmentsButton.IsEnabled = false;
                PatientAppointmentsButton.IsEnabled = false;
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new ClinicTab());
            }
        }

        //Metoda dodająca nowy element do bazy
        private void AddNewButtonClick(object sender, RoutedEventArgs e)
        {
            if (TabsComboBox.SelectedIndex == 1)
            {
                PatientForm PatientWindow = new PatientForm();
                PatientWindow.DataChanged += PatientWindow_DataChanged;
                PatientWindow.Show();
            }
            else if(TabsComboBox.SelectedIndex == 0)
            {
                AppointmentForm AppointmentTab = new AppointmentForm();
                AppointmentTab.DataChanged += AppoinmentWindow_DataChanged;
                AppointmentTab.Show();
                TodayAppointmentsButton.Content = "Dzisiejsze wizyty";
            }
            
        }

        //Metoda edytująca element w bazie
        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (TabsComboBox.SelectedIndex == 0)
            {
                int index = AppointmentTab.AppointmentIndex;
                AppointmentForm AppoinmentWindow = new AppointmentForm(index);
                AppoinmentWindow.DataChanged += AppoinmentWindow_DataChanged;
                AppoinmentWindow.Show();
                TodayAppointmentsButton.Content = "Dzisiejsze wizyty";
            }
            else if (TabsComboBox.SelectedIndex == 1)
            {
                int index = PatientTab.PatientIndex;
                PatientForm PatientWindow = new PatientForm(index);
                PatientWindow.DataChanged += PatientWindow_DataChanged;
                PatientWindow.Show();

            }
        }

        //Metoda usuwająca element z bazy
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (TabsComboBox.SelectedIndex == 0)
            {
                MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć?", "Alert", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    int index = AppointmentTab.AppointmentIndex;
                    AppointmentRepo.DeleteAppointment(Lists.Appointments[index].ID_wizyty.ToString());
                    TableSpace.Children.Clear();
                    TableSpace.Children.Add(new AppointmentTab(1));

                }     
            }
            else if (TabsComboBox.SelectedIndex == 1)
            {
                MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć?", "Alert", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    int index = PatientTab.PatientIndex;
                    if (DeletePeselCheck(Lists.Patients[index].PESEL) == true)
                        MessageBox.Show("Nie można usunąć pacjenta z wizytami!");
                    else
                    {
                        PatientRepo.DeletePatient(Lists.Patients[index].PESEL);
                        TableSpace.Children.Clear();
                        TableSpace.Children.Add(new PatientTab());
                    }

                }
            }
        }

        //Odświeżenie widoku wizyt w przypadku zmiany
        private void AppoinmentWindow_DataChanged(object sender, EventArgs e)
        {
            TableSpace.Children.Clear();
            TableSpace.Children.Add(new AppointmentTab(1));
            TodayAppointmentsButton.Content = "Dzisiejsze wizyty";
        }

        //Odświeżenie widoku pacjentów w przypadku zmiany
        private void PatientWindow_DataChanged(object sender, EventArgs e)
        {
            TableSpace.Children.Clear();
            TableSpace.Children.Add(new PatientTab());
        }
        
        //Metoda sprawdzająca czy dany PESEL jest w użyciu
        bool DeletePeselCheck(string Pesel)
        {
            foreach (var item in Lists.Appointments)
                if (item.PESEL == Pesel)
                    return true;             
            return false;
        }

        //Metoda wyświetlająca wizyty dla pacjenta lub lekarza
        private void PersonsAppointmentsClick(object sender, RoutedEventArgs e)
        {
            if (PatientAppointmentsButton.Content.ToString() == "Wizyty Pacjenta" & TabsComboBox.SelectedIndex == 1)
            {
                
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new AppointmentTab(3));

                AddContent.IsEnabled = false;
                EditContent.IsEnabled = false;
                DeleteContent.IsEnabled = false;
                TabsComboBox.IsEnabled = false;
                TodayAppointmentsButton.IsEnabled = false;

                PatientAppointmentsButton.Content = "Wszystkie wizyty";
            }
            else if (PatientAppointmentsButton.Content.ToString() == "Wizyty Lekarza" & TabsComboBox.SelectedIndex == 2)
            {
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new AppointmentTab(4));

                AddContent.IsEnabled = false;
                EditContent.IsEnabled = false;
                DeleteContent.IsEnabled = false;
                TabsComboBox.IsEnabled = false;
                TodayAppointmentsButton.IsEnabled = false;

                PatientAppointmentsButton.Content = "Wszystkie wizyty";
            }
            else if (PatientAppointmentsButton.Content.ToString() == "Wszystkie wizyty")
            {
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new AppointmentTab(1));

                AddContent.IsEnabled = true;
                EditContent.IsEnabled = true;
                DeleteContent.IsEnabled = true;
                TabsComboBox.IsEnabled = true;
                TabsComboBox.SelectedIndex = 0;

                PatientAppointmentsButton.Content = "Wizyty Pacjenta";
            }
        }

        //Metoda wyświetlająca dzisiejsze wizyty
        private void TodayAppointmentsClick(object sender, RoutedEventArgs e)
        {
            if (TodayAppointmentsButton.Content.ToString() == "Dzisiejsze wizyty")
            {
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new AppointmentTab(2));
                TodayAppointmentsButton.Content = "Wszystkie wizyty";
                TabsComboBox.IsEnabled = false;
            }
            else if (TodayAppointmentsButton.Content.ToString() == "Wszystkie wizyty")
            {
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new AppointmentTab(1));
                TodayAppointmentsButton.Content = "Dzisiejsze wizyty";
                TabsComboBox.IsEnabled = true;
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginScreen window = new LoginScreen();
            window.Show();
            this.Close();
        }
    }
}
