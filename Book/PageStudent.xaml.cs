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

namespace Book
{
    /// <summary>
    /// Логика взаимодействия для PageStudent.xaml
    /// </summary>
    public partial class PageStudent : Window
    {
        public PageStudent()
        {
            InitializeComponent();
            MainFrame1.Navigate(new BookPageStudent());
            Manager.MainFrame1 = MainFrame1;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame1.GoBack();
        }

        private void MainFrame1_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame1.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}
