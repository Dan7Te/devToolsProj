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
    /// Логика взаимодействия для KategoriaADD.xaml
    /// </summary>
    public partial class KategoriaADD : Page
    {
        private категория_клиента _currenkategoria = new категория_клиента();
        public KategoriaADD(категория_клиента selectedкатегория_клиента)
        {
            InitializeComponent();
            if (selectedкатегория_клиента != null)
                _currenkategoria = selectedкатегория_клиента;
            DataContext = _currenkategoria;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Kategoria.Text)) errors.AppendLine("Введите категорию клиента");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var maxId = КурсоваяEntities.GetContext().категория_клиента.Max(item => item.id);
            if (_currenkategoria.id == 0)
            {
                _currenkategoria.id = maxId + 1;
            }
            else
            {
                var tar = КурсоваяEntities.GetContext().категория_клиента.Where(c => c.id == _currenkategoria.id).FirstOrDefault();

                tar.категория = Kategoria.Text;

                КурсоваяEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех");
                return;
            }
            КурсоваяEntities.GetContext().категория_клиента.Add(_currenkategoria);
            КурсоваяEntities.GetContext().SaveChanges();

        }
    }
}
