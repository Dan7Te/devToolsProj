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
    /// Логика взаимодействия для YsloviaADD.xaml
    /// </summary>
    public partial class YsloviaADD : Page
    {
        private условия_выпуска _curreneslovia = new условия_выпуска();
        public YsloviaADD(условия_выпуска selectedусловия_выпуска)
        {
            InitializeComponent();
            if (selectedусловия_выпуска != null)
                _curreneslovia = selectedусловия_выпуска;
            DataContext = _curreneslovia;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(yslovia.Text)) errors.AppendLine("Введите условие выпуска");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var maxId = курсоваяEntities.GetContext().условия_выпуска.Max(item => item.id);
            if (_curreneslovia.id == 0)
            {
                _curreneslovia.id = maxId + 1;
            }
            else
            {
                var ysl = курсоваяEntities.GetContext().условия_выпуска.Where(c => c.id == _curreneslovia.id).FirstOrDefault();

                ysl.сроки_выпуска = yslovia.Text;

                курсоваяEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех");
                return;
            }
            курсоваяEntities.GetContext().условия_выпуска.Add(_curreneslovia);
            курсоваяEntities.GetContext().SaveChanges();

        }
    }
}
