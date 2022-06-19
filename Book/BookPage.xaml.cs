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

namespace Book
{
    /// <summary>
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        public BookPage()
        {
            InitializeComponent();
            //DGridBook.ItemsSource = BookBaseEntities.GetContext().BookTest.ToList();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as BookTest));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var BooktesstForRemoving = DGridBook.SelectedItems.Cast<BookTest>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следущие {BooktesstForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BookBaseEntities.GetContext().BookTest.RemoveRange(BooktesstForRemoving);
                    BookBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridBook.ItemsSource = BookBaseEntities.GetContext().BookTest.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BookBaseEntities.GetContext().ChangeTracker.Entries().ToList();
                DGridBook.ItemsSource = BookBaseEntities.GetContext().BookTest.ToList();
            }
        }
    }
}
