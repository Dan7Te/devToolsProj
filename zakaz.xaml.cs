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
    /// Логика взаимодействия для zakaz.xaml
    /// </summary>
    public partial class zakaz : Page
    {
        public zakaz()
        {
            InitializeComponent();
            datagridzakaz.Items.Clear();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                КурсоваяEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagridzakaz.ItemsSource = КурсоваяEntities.GetContext().Заказы.ToList();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Заказы obj = ((FrameworkElement)sender).DataContext as Заказы;
            NavigationService.Navigate(new ZakazADD((sender as Button).DataContext as Заказы));
        }

        
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = datagridzakaz.SelectedItems.Cast<Заказы>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в кол-ве {usersForRemoving.Count} эл-ов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    КурсоваяEntities.GetContext().Заказы.RemoveRange(usersForRemoving);
                    КурсоваяEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    datagridzakaz.ItemsSource =
                    КурсоваяEntities.GetContext().Заказы.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZakazADD(null));

        }
    }
}
