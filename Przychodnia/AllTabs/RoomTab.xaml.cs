using System.Collections.Generic;
using System.Windows.Controls;
using Przychodnia.DAL.Encje;
using Przychodnia.DAL.Repozytoria;

namespace Przychodnia.AllTabs
{
    public partial class RoomTab : UserControl
    {
        //Konstruktor
        public RoomTab()
        {
            InitializeComponent();
            List<Room> RoomList = RoomRepo.GetAllRooms();
            RoomListView.ItemsSource = RoomList;
        }
    }
}
