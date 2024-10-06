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
    /// Логика взаимодействия для OfficeADD.xaml
    /// </summary>
    public partial class OfficeADD : Page
    {
        private офисы _currenoffice = new офисы();
        public OfficeADD(офисы selectedофисы)
        {
            InitializeComponent();
            if (selectedофисы != null)
                _currenoffice = selectedофисы;
            DataContext = _currenoffice;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(office.Text)) errors.AppendLine("Введите название офиса");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var maxId = КурсоваяEntities.GetContext().офисы.Max(item => item.id);
            if (_currenoffice.id == 0)
            {
                _currenoffice.id = maxId + 1;
            }
            else
            {
                var tar = КурсоваяEntities.GetContext().офисы.Where(c => c.id == _currenoffice.id).FirstOrDefault();

                tar.офис = office.Text;

                КурсоваяEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех");
                return;
            }
            КурсоваяEntities.GetContext().офисы.Add(_currenoffice);
            КурсоваяEntities.GetContext().SaveChanges();


        }
    }
}
