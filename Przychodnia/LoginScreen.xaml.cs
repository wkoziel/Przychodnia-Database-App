using System.Collections.Generic;
using System.Windows;
using Przychodnia.DAL.Encje;
using Przychodnia.DAL;
using Przychodnia.DAL.Repozytoria;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IfDoctor { get; set; }

        public LoginScreen()
        {
            InitializeComponent();
        }

        private bool UserCheck(string nickname, string password)
        {
            List<Users> Users = UsersRepo.GetAllUsers();

            if (Users.Count == 0)
            {
                MessageBox.Show("Brak dostępu do bazy użytkowników!");
                return false;
            }

            foreach (var user in Users)
                if (user.Login == nickname && user.Haslo == password)
                    return true;

            MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło!");
            return false;

        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string nick = textBoxLogin.Text;
            string password = textBoxPassword.Password;
            if (UserCheck(nick, password) == false) 
            {
                MessageBox.Show("Niepoprawny login lub hasło!");
                return;
            }
            
            DBConnection.Login(nick, password);
            
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
