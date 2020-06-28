using System.Windows.Controls;
using Przychodnia.DAL.Encje;
using Przychodnia.DAL.Repozytoria;
using System.Collections.Generic;

namespace Przychodnia.AllTabs
{
    public partial class DoctorTab : UserControl
    {
        public DoctorTab()
        {
            InitializeComponent();
            List<Doctor> DoctorList = DoctorRepo.GetAllDoctors();
            DoctorListView.ItemsSource = DoctorList;
        }
    }
}
