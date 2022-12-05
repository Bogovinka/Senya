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

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginB_Click(object sender, RoutedEventArgs e)
        {
            DatabaseLibEntities db = new DatabaseLibEntities();
            if (db.Client.Where(x => x.Login == loginText.Text && x.Password == passwordText.Password).Count() > 0)
            {
                Client s = db.Client.Where(x => x.Login == loginText.Text && x.Password == passwordText.Password).FirstOrDefault();
                MessageBox.Show($"Вход выполнен под пользователем {s.FullName}");
                ClientMenu sM = new ClientMenu(s.ID_c);
                sM.Show();
                Close();
            }
            else if (loginText.Text == "admin" && passwordText.Password == "admin")
            {
                AdminMenu p = new AdminMenu();
                MessageBox.Show($"Вход выполнен под администратором");
                p.Show();
                Close();
            }
            else MessageBox.Show("Такого логина или пароля не существует");
        }
    }
}
