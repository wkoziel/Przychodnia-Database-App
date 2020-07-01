using Przychodnia.DAL.Encje;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Przychodnia.Tabs
{
    using Przychodnia.DAL.Repozytoria;
    public partial class AppointmentTab : UserControl
    {
        static public int AppointmentIndex{get; set;}
        
        //Konstruktor wyświetla dane w zależności od wyboru
        public AppointmentTab(int ViewType)
        {
            InitializeComponent();
            List<Appointment> AppointmentList = AppointmentRepo.GetAllAppoitments();
            if (ViewType == 1)
                AppointmentListView.ItemsSource = AppointmentList;
            else if (ViewType == 2)
                AppointmentListView.ItemsSource = Lists.TodayAppointments();
            else if (ViewType == 3)
                AppointmentListView.ItemsSource = Lists.PatientAppointments();
            else if (ViewType == 4)
                AppointmentListView.ItemsSource = Lists.DoctorAppointments();


            AppointmentListView.Items.Refresh();
        }

        //Metoda przechowująca aktualnie zaznaczony index tabeli
        private void AppointmentIndexChange(object sender, SelectionChangedEventArgs e)
        {
            AppointmentIndex = AppointmentListView.SelectedIndex;
        }

    }
}
