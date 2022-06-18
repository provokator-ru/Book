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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private BookTest _currentBook = new BookTest();
        public AddEditPage(BookTest selectedBook)
        {
            InitializeComponent();
            if (selectedBook != null)
                _currentBook = selectedBook;
            DataContext = _currentBook;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentBook.ID == 0)
            {
                BookBaseEntities.GetContext().BookTest.Add(_currentBook);
            }
            try
            {
                BookBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохраненa!!!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
