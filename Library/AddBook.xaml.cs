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
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        DatabaseLibEntities db = new DatabaseLibEntities();
        public AddBook()
        {
            InitializeComponent();
            TypeT.ItemsSource = db.Type_book.ToList();
            AuthorT.ItemsSource = db.Author.ToList();
        }
        public AddBook(Book b)
        {
            InitializeComponent();
            TypeT.ItemsSource = db.Type_book.ToList();
            AuthorT.ItemsSource = db.Author.ToList();
            TypeT.Text = b.Type_book.Name_t;
            AuthorT.Text = b.Author.Name_a;
            nameT.Text = b.Name_b;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void createB_Click(object sender, RoutedEventArgs e)
        {
            if (nameT.Text != "" && TypeT.Text != "" && AuthorT.Text != "")
            {
                DialogResult = true;
            }
            else MessageBox.Show("Заполни все поля");
        }
    }
}
