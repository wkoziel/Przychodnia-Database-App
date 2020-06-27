using Przychodnia.DAL.Encje;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Przychodnia.DAL;
namespace Przychodnia.Tabs
{
    /// <summary>
    /// Interaction logic for AppointmentTab.xaml
    /// </summary>
    public partial class AppointmentTab : UserControl
    {
        public AppointmentTab()
        {
            InitializeComponent();
            FillAppointmentTab();
        }

        //Metoda wypełniająca listę
        //Wojtek: Nie umiem wypełniać tego typu listy, to jest do zmieny całe xd
        void FillAppointmentTab()
        {
            List<Appointment> appointments =  Queries.Appointments;
            foreach (var item in appointments)
                Wizyta.Items.Add(item);
            Wizyta.Items.Refresh();
        }

        //Metoda którą wybiera się element z listy
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Po wybraniu elementu możemy edytować jego składowe - nowa strona/usercontroll
        }
    }
}
