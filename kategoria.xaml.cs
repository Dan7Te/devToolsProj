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
    /// Логика взаимодействия для kategoria.xaml
    /// </summary>
    public partial class kategoria : Page
    {
        public kategoria()
        {
            InitializeComponent();
            datagridkaregoria.Items.Clear();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = datagridkaregoria.SelectedItems.Cast<категория_клиента>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в кол-ве {usersForRemoving.Count} эл-ов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    КурсоваяEntities.GetContext().категория_клиента.RemoveRange(usersForRemoving);
                    КурсоваяEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    datagridkaregoria.ItemsSource =
                    КурсоваяEntities.GetContext().категория_клиента.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KategoriaADD(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            категория_клиента obj = ((FrameworkElement)sender).DataContext as категория_клиента;
            NavigationService.Navigate(new KategoriaADD((sender as Button).DataContext as категория_клиента));
           
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                КурсоваяEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagridkaregoria.ItemsSource = КурсоваяEntities.GetContext().категория_клиента.ToList();
            }
        }
    }
}
