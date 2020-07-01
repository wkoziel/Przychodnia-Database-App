using Przychodnia.DAL.Encje;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Przychodnia.Tabs
{
    using Przychodnia.DAL.Repozytoria;
    public partial class AppointmentTab : UserControl
    {
        static public int AppointmentIndex{get; set;}
        public AppointmentTab()
        {
            InitializeComponent();
            List<Appointment> AppointmentList = AppointmentRepo.GetAllAppoitments();
            AppointmentListView.ItemsSource = AppointmentList;
        }

        private void AppointmentIndexChange(object sender, SelectionChangedEventArgs e)
        {
            AppointmentIndex = AppointmentListView.SelectedIndex;
        }

        private void RefreshAppointmentList()
        {
            AppointmentListView.Items.Refresh();
        }
    }
}
