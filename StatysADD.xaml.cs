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
    /// Логика взаимодействия для StatysADD.xaml
    /// </summary>
    public partial class StatysADD : Page
    {
        private статус_карты _currenstatys = new статус_карты();
        public StatysADD(статус_карты selectedстатус_карты)
        {
            InitializeComponent();
            if (selectedстатус_карты != null)
                _currenstatys = selectedстатус_карты;
            DataContext = _currenstatys;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(statys.Text)) errors.AppendLine("Введите статус карты");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var maxId = курсоваяEntities.GetContext().статус_карты.Max(item => item.id);
            if (_currenstatys.id == 0)
            {
                _currenstatys.id = maxId + 1;
            }
            else
            {
                var tar = курсоваяEntities.GetContext().статус_карты.Where(c => c.id == _currenstatys.id).FirstOrDefault();

                tar.статус = statys.Text;

                курсоваяEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех");
                return;
            }
            курсоваяEntities.GetContext().статус_карты.Add(_currenstatys);
            курсоваяEntities.GetContext().SaveChanges();
        }
    }
}
