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
using Przychodnia.DAL.Encje;
using Przychodnia.DAL.Repozytoria;

namespace Przychodnia.AllTabs
{
    public partial class PatientTab : UserControl
    {
        public PatientTab()
        {
            InitializeComponent();
            List<Patient> PatientList = PatientRepo.GetAllPatients();
            PatientListView.ItemsSource = PatientList;
        }

        private void PatientListSelection(object sender, SelectionChangedEventArgs e)
        {
            ;
        }
    }
}
