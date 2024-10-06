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
    /// Логика взаимодействия для kart.xaml
    /// </summary>
    /// 
    public partial class kart : Page
    {
        public kart()
        {
            InitializeComponent();
            datagridKarta.Items.Clear();
            datagridKarta.ItemsSource = КурсоваяEntities.GetContext().клиент.ToList();
        }

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KartaADD(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                КурсоваяEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagridKarta.ItemsSource = КурсоваяEntities.GetContext().карты.ToList();
            }

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = datagridKarta.SelectedItems.Cast<карты>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в кол-ве {usersForRemoving.Count} эл-ов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    КурсоваяEntities.GetContext().карты.RemoveRange(usersForRemoving);
                    КурсоваяEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    datagridKarta.ItemsSource =
                    КурсоваяEntities.GetContext().карты.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            карты obj = ((FrameworkElement)sender).DataContext as карты;
            NavigationService.Navigate(new KartaADD((sender as Button).DataContext as карты));
        }
    }
}
