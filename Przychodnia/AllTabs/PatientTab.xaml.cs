using System.Collections.Generic;
using System.Windows.Controls;
using Przychodnia.DAL.Encje;
using Przychodnia.DAL.Repozytoria;

namespace Przychodnia.AllTabs
{
    public partial class PatientTab : UserControl
    {
        static public int PatientIndex { get; set; }
        
        //Konstruktor
        public PatientTab()
        {
            InitializeComponent();
            List<Patient> PatientList = PatientRepo.GetAllPatients();
            PatientListView.ItemsSource = PatientList;
        }

        //Metoda przechowująca aktualnie zaznaczony index tabeli
        private void PatientListSelection(object sender, SelectionChangedEventArgs e)
        {
            PatientIndex = PatientListView.SelectedIndex;
        }
    }
}
