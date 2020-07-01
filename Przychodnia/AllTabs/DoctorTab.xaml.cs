using System.Windows.Controls;
using Przychodnia.DAL.Encje;
using Przychodnia.DAL.Repozytoria;
using System.Collections.Generic;

namespace Przychodnia.AllTabs
{
    public partial class DoctorTab : UserControl
    {
        static public int DoctorIndex { get; set; }
        
        //Konstruktor
        public DoctorTab()
        {
            InitializeComponent();
            List<Doctor> DoctorList = DoctorRepo.GetAllDoctors();
            DoctorListView.ItemsSource = DoctorList;
        }

        //Metoda przechowująca aktualnie zaznaczony index tabeli
        private void DoctorListSelection(object sender, SelectionChangedEventArgs e)
        {
            DoctorIndex = DoctorListView.SelectedIndex;
        }
    }
}
