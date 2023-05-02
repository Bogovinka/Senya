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
            booksDG.ItemsSource = db.Book.ToList();
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

        private void addBook_Click(object sender, RoutedEventArgs e)
        {
            AddBook b = new AddBook();
            if(b.ShowDialog() == true)
            {
                Book book = new Book()
                {
                    Name_b = b.nameT.Text,
                    Type_book = db.Type_book.Where(x => x.ID_t == (int)b.TypeT.SelectedValue).FirstOrDefault(),
                    Type_book_id = (int)b.TypeT.SelectedValue,
                    Author = db.Author.Where(x => x.ID_a == (int)b.AuthorT.SelectedValue).FirstOrDefault(),
                    Author_id = (int)b.AuthorT.SelectedValue
                };
                db.Book.Add(book);
                db.SaveChanges();
                booksDG.ItemsSource = db.Book.ToList();
            }
        }

        private void editBook_Click(object sender, RoutedEventArgs e)
        {
            if (booksDG.SelectedItem != null)
            {
                Book book = (Book)booksDG.SelectedItem;
                AddBook b = new AddBook(book);
                if (b.ShowDialog() == true)
                {
                    book.Name_b = b.nameT.Text;
                    book.Type_book = db.Type_book.Where(x => x.ID_t == (int)b.TypeT.SelectedValue).FirstOrDefault();
                    book.Type_book_id = (int)b.TypeT.SelectedValue;
                    book.Author = db.Author.Where(x => x.ID_a == (int)b.AuthorT.SelectedValue).FirstOrDefault();
                    book.Author_id = (int)b.AuthorT.SelectedValue;
                    db.SaveChanges();
                    booksDG.ItemsSource = db.Book.ToList();
                }
            }
        }

        private void delBook_Click(object sender, RoutedEventArgs e)
        {
            if(booksDG.SelectedItem != null)
            {
                Book b = (Book)booksDG.SelectedItem;
                if (db.Accounting.Where(x => x.Book_id == b.ID_b).Count() == 0)
                {
                    db.Book.Remove(b);
                    db.SaveChanges();
                    booksDG.ItemsSource = db.Book.ToList();
                }
                else MessageBox.Show("Эту книгу не вернул клиент");
            }
        }
    }
}
