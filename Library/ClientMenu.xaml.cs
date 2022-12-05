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
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для ClientMenu.xaml
    /// </summary>
    public partial class ClientMenu : Window
    {
        int idC;
        DatabaseLibEntities db = new DatabaseLibEntities();
        public ClientMenu(int id)
        {
            InitializeComponent();
            idC = id;
            bookDG.ItemsSource = db.Book.ToList();
            bookMyDG.ItemsSource = db.Accounting.Where(x => x.Client_id == idC).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Accounting book = bookDG.SelectedItem as Accounting;
            Accounting newAc = new Accounting
            {
                Book_id = Convert.ToInt32(((Button)sender).Tag),
                Client_id = idC,
                Date_a = DateTime.Now
            };
            db.Accounting.Add(newAc);
            db.SaveChanges();
            bookDG.ItemsSource = db.Book.ToList();
            bookMyDG.ItemsSource = db.Accounting.Where(x => x.Client_id == idC).ToList();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.R)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
        }
    }
}
