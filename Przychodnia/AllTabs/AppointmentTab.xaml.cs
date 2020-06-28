using Przychodnia.DAL.Encje;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Przychodnia.Tabs
{
    using Przychodnia.DAL.Repozytoria;
    public partial class AppointmentTab : UserControl
    {
        public AppointmentTab()
        {
            InitializeComponent();
            List<Appointment> AppointmentList = AppointmentRepo.GetAllAppoitments();
            AppointmentListView.ItemsSource = AppointmentList;
        }
    }
}
