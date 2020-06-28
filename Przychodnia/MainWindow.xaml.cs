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
                PatientForm window = new PatientForm();
                window.Show();
            }
            else if(TabsComboBox.SelectedIndex == 0)
            {
                AppointmentForm window = new AppointmentForm();
                window.Show();
            }
            
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (TabsComboBox.SelectedIndex == 1)
            {
                PatientForm window = new PatientForm();
                window.Show();
            }
            else if (TabsComboBox.SelectedIndex == 0)
            {
                AppointmentForm window = new AppointmentForm();
                window.Show();
            }
        }
    }
}
