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
    /// Логика взаимодействия для clienttable.xaml
    /// </summary>
    public partial class clienttable : Page
    {
        public clienttable()
        {
            InitializeComponent();
           datagridklient.Items.Clear(); // Очистить элементы DataGrid
            //datagridklient.ItemsSource = курсоваяEntities.GetContext().клиент.ToList();
        }

       

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new clientADD(null));
        }
        private  void Del_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = datagridklient.SelectedItems.Cast<клиент>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в кол-ве {usersForRemoving.Count} эл-ов?", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    КурсоваяEntities.GetContext().клиент.RemoveRange(usersForRemoving);
                    КурсоваяEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    datagridklient.ItemsSource =
                    КурсоваяEntities.GetContext().клиент.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            клиент obj = ((FrameworkElement)sender).DataContext as клиент;
            NavigationService.Navigate(new clientADD ((sender as Button).DataContext as клиент));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                КурсоваяEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p=>p.Reload() );
                datagridklient.ItemsSource = КурсоваяEntities.GetContext().клиент.ToList();
            }
        }
    }
}
