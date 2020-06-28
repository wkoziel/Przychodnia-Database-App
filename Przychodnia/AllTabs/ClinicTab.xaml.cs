using System.Collections.Generic;
using System.Windows.Controls;
using Przychodnia.DAL.Encje;
using Przychodnia.DAL.Repozytoria;

namespace Przychodnia.AllTabs
{

    public partial class ClinicTab : UserControl
    {
        public ClinicTab()
        {
            InitializeComponent();
            List<Clinic> ClinicList = ClinicRepo.GetAllClinics();
            ClinicListView.ItemsSource = ClinicList;
        }
    }
}
