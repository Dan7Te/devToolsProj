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

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для office.xaml
    /// </summary>
    public partial class office : Page
    {
        public office()
        {
            InitializeComponent();
            datagridOffice.Items.Clear();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                курсоваяEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagridOffice.ItemsSource = курсоваяEntities.GetContext().офисы.ToList();
            }
        }

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new OfficeADD(null));
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = datagridOffice.SelectedItems.Cast<офисы>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в кол-ве {usersForRemoving.Count} эл-ов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    курсоваяEntities.GetContext().офисы.RemoveRange(usersForRemoving);
                    курсоваяEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    datagridOffice.ItemsSource =
                    курсоваяEntities.GetContext().офисы.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            офисы obj = ((FrameworkElement)sender).DataContext as офисы;
            NavigationService.Navigate(new OfficeADD((sender as Button).DataContext as офисы));
        }

        
    }
}
