using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }



        private void admin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new admin());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new klient());
        }





    }
}

