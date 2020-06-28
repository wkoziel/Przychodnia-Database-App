using Przychodnia.AllTabs;
using Przychodnia.DAL;
using Przychodnia.DAL.Repozytoria;
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
            DoctorRepo.GetAllDoctors(); //Testowo wyświetla w outpucie zawartość tabeli lekarze - test poprawności połączenia z bazą
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
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new AppointmentTab());
            }
            else if(choice == 1)
            {
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new PatientTab());
            }
            else if (choice == 2)
            {
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new DoctorTab());
            }
            else if (choice == 3)
            {
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new RoomTab());
            }
            else if (choice == 4)
            {
                TableSpace.Children.Clear();
                TableSpace.Children.Add(new ClinicTab());
            }
        }
    }
}
