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
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        DatabaseLibEntities db = new DatabaseLibEntities();
        public AdminMenu()
        {
            InitializeComponent();
            bookMyDG.ItemsSource = db.Accounting.ToList();
        }

        private void SaveB_Click(object sender, RoutedEventArgs e)
        {
            if(bookMyDG.SelectedItem != null) {
                Accounting ac = bookMyDG.SelectedItem as Accounting;
                db.Accounting.Remove(ac);
                db.SaveChanges();
                bookMyDG.ItemsSource = db.Accounting.ToList();
            }
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
