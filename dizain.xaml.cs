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
    /// Логика взаимодействия для dizain.xaml
    /// </summary>
    public partial class dizain : Page
    {
        public dizain()
        {
            InitializeComponent();
            datagridiz.Items.Clear();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = datagridiz.SelectedItems.Cast<дизайн>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в кол-ве {usersForRemoving.Count} эл-ов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    КурсоваяEntities.GetContext().дизайн.RemoveRange(usersForRemoving);
                    КурсоваяEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    datagridiz.ItemsSource =
                    КурсоваяEntities.GetContext().дизайн.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        private void Dobavit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                КурсоваяEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagridiz.ItemsSource = КурсоваяEntities.GetContext().дизайн.ToList();
            }
        }
    }
}
