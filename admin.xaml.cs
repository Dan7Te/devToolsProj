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
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Page
    {
        public admin()
        {
            InitializeComponent();
        }

        private void checkklient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new clienttable());
        }

        private void checkKart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new kart());
        }

        private void checkZakaz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new zakaz());
        }

        private void checkSchet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new shet());
        }

        private void checkdizain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new dizain());

        }

        private void checktarif_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new tarif());
        }

        private void checkyslovia_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new yslovia());
        }

        private void checkkategoria_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new kategoria());
        }

        private void checkOffice_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new office());
        }

        private void checkstatys_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new statys());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new otchetTarif ());
        }

        private void checkDiz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new otchetDizain());

        }
    }
}
