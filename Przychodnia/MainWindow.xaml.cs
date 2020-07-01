using Przychodnia.AllTabs;
using Przychodnia.DAL;
using Przychodnia.DAL.Repozytoria;
using Przychodnia.Functions;
using Przychodnia.Tabs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Przychodnia.AllTabs;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillTabsComboBox();
        }

        //Wypełnia ComboBox nazwami tabel
        void FillTabsComboBox()
        {
            TabsComboBox.Items.Add("Wizyty");
            TabsComboBox.Items.Add("Pacjenci");
            TabsComboBox.Items.Add("Lekarze");
            TabsComboBox.Items.Add("Sale");
            TabsComboBox.Items.Add("Poradnie");
            TabsComboBox.Items.Refresh();
        }

        private void ChangeTableComboBox(object sender, SelectionChangedEventArgs e)
        {
            int choice = TabsComboBox.SelectedIndex;
            if (choice == 0)
            {
                AddContent.IsEnabled = true;
                EditContent.IsEnabled = true;
                DeleteContent.IsEnabled = true;
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new AppointmentTab());
            }
            else if(choice == 1)
            {
                AddContent.IsEnabled = true;
                EditContent.IsEnabled = true;
                DeleteContent.IsEnabled = true;
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new PatientTab());
            }
            else if (choice == 2)
            {
                AddContent.IsEnabled = false;
                EditContent.IsEnabled = false;
                DeleteContent.IsEnabled = false;
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new DoctorTab());
            }
            else if (choice == 3)
            {
                AddContent.IsEnabled = false;
                EditContent.IsEnabled = false;
                DeleteContent.IsEnabled = false;
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new RoomTab());
            }
            else if (choice == 4)
            {
                AddContent.IsEnabled = false;
                EditContent.IsEnabled = false;
                DeleteContent.IsEnabled = false;
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new ClinicTab());
            }
        }

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
            }
            
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (TabsComboBox.SelectedIndex == 0)
            {
                int index = AppointmentTab.AppointmentIndex;
                AppointmentForm AppoinmentWindow = new AppointmentForm(index);
                AppoinmentWindow.DataChanged += AppoinmentWindow_DataChanged;
                AppoinmentWindow.Show();
            }
            else if (TabsComboBox.SelectedIndex == 1)
            {
                int index = PatientTab.PatientIndex;
                PatientForm PatientWindow = new PatientForm(index);
                PatientWindow.DataChanged += PatientWindow_DataChanged;
                PatientWindow.Show();
            }
        }

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
                    TableSpace.Children.Add(new AppointmentTab());
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
        private void AppoinmentWindow_DataChanged(object sender, EventArgs e)
        {
            TableSpace.Children.Clear();
            TableSpace.Children.Add(new AppointmentTab());
        }

        private void PatientWindow_DataChanged(object sender, EventArgs e)
        {
            TableSpace.Children.Clear();
            TableSpace.Children.Add(new PatientTab());
        }
        
        bool DeletePeselCheck(string Pesel)
        {
            foreach (var item in Lists.Appointments)
                if (item.PESEL == Pesel)
                    return true;             
            return false;
        }
    }
}
