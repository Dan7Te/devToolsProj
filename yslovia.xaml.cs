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
    /// Логика взаимодействия для yslovia.xaml
    /// </summary>
    public partial class yslovia : Page
    {
        public yslovia()
        {
            InitializeComponent();
            datagridyslov.Items.Clear();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            условия_выпуска obj = ((FrameworkElement)sender).DataContext as условия_выпуска;
            NavigationService.Navigate(new YsloviaADD ((sender as Button).DataContext as условия_выпуска));
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = datagridyslov.SelectedItems.Cast<условия_выпуска>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в кол-ве {usersForRemoving.Count} эл-ов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    курсоваяEntities.GetContext().условия_выпуска.RemoveRange(usersForRemoving);
                    курсоваяEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    datagridyslov.ItemsSource =
                    курсоваяEntities.GetContext().тариф.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                курсоваяEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagridyslov.ItemsSource = курсоваяEntities.GetContext().условия_выпуска.ToList();
            }
            
        }

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new YsloviaADD(null));
        }
    }
}
 