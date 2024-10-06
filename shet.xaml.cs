using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для shet.xaml
    /// </summary>
    public partial class shet : Page
    {
        public shet()
        {
            InitializeComponent();
            datagridschet.Items.Clear();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

            var usersForRemoving = datagridschet.SelectedItems.Cast<счета>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в кол-ве {usersForRemoving.Count} эл-ов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    курсоваяEntities.GetContext().счета.RemoveRange(usersForRemoving);
                    курсоваяEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    datagridschet.ItemsSource =
                    курсоваяEntities.GetContext().счета.ToList();
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
                datagridschet.ItemsSource = курсоваяEntities.GetContext().счета.ToList();
            }
        }
    }
}

