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
    /// Логика взаимодействия для statys.xaml
    /// </summary>
    public partial class statys : Page
    {
        public statys()
        {
            InitializeComponent();
            datagridstatys.Items.Clear();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = datagridstatys.SelectedItems.Cast<статус_карты>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в кол-ве {usersForRemoving.Count} эл-ов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    КурсоваяEntities.GetContext().статус_карты.RemoveRange(usersForRemoving);
                    КурсоваяEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    datagridstatys.ItemsSource =
                    КурсоваяEntities.GetContext().статус_карты.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatysADD(null));

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            статус_карты obj = ((FrameworkElement)sender).DataContext as статус_карты;
            NavigationService.Navigate(new StatysADD((sender as Button).DataContext as статус_карты));

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                КурсоваяEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagridstatys.ItemsSource = КурсоваяEntities.GetContext().статус_карты.ToList();
            }
        }
    }
}
