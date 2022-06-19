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
    /// Логика взаимодействия для BookPageStudent.xaml
    /// </summary>
    public partial class BookPageStudent : Page
    {
        public BookPageStudent()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame1.Navigate(new ProsmotrPageStudent((sender as Button).DataContext as BookTest));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame1.Navigate(new ProsmotrPageStudent(null));
        }

        private void Page_IsVisibleChanged1(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BookBaseEntities.GetContext().ChangeTracker.Entries().ToList();
                DGridBook.ItemsSource = BookBaseEntities.GetContext().BookTest.ToList();
            }
        }
    }
}
