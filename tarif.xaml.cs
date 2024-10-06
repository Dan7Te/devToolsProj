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
    /// Логика взаимодействия для tarif.xaml
    /// </summary>
    public partial class tarif : Page
    {
        public tarif()
        {
            InitializeComponent();
            datagridtarif.Items.Clear();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                курсоваяEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagridtarif.ItemsSource = курсоваяEntities.GetContext().тариф.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            тариф obj = ((FrameworkElement)sender).DataContext as тариф;
            NavigationService.Navigate(new TarifADD ((sender as Button).DataContext as тариф));

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = datagridtarif.SelectedItems.Cast<тариф>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в кол-ве {usersForRemoving.Count} эл-ов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    курсоваяEntities.GetContext().тариф.RemoveRange(usersForRemoving);
                    курсоваяEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    datagridtarif.ItemsSource =
                    курсоваяEntities.GetContext().тариф.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TarifADD(null));
        }
    }
}
