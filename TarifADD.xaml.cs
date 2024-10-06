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
using static Google.Protobuf.Reflection.UninterpretedOption.Types;

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для TarifADD.xaml
    /// </summary>
    public partial class TarifADD : Page
    {
        private тариф _currentarif = new тариф();
        public TarifADD(тариф selectedтариф)
        {
            InitializeComponent();
            if (selectedтариф != null)
                _currentarif = selectedтариф;
            DataContext = _currentarif;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(tarif.Text)) errors.AppendLine("Введите название тарифа");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var maxId = курсоваяEntities.GetContext().тариф.Max(item => item.id);
            if (_currentarif.id == 0)
            {
                _currentarif.id = maxId + 1;
            }
            else
            {
                var tar= курсоваяEntities.GetContext().тариф.Where(c => c.id == _currentarif.id).FirstOrDefault();

                tar.тарифы = tarif.Text;
                
                курсоваяEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех");
                return;
            }
            курсоваяEntities.GetContext().тариф.Add(_currentarif);
            курсоваяEntities.GetContext().SaveChanges();

        }
    }
}
