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
    /// Логика взаимодействия для ZakazADD.xaml
    /// </summary>
    public partial class ZakazADD : Page
    {
        //private клиент _currentUser = new клиент();
        private Заказы _currenzak = new Заказы();
        //private счета _currenshet = new счета();
        public ZakazADD(Заказы selectedзаказы)
        {
            InitializeComponent();
            if (selectedзаказы != null)
                _currenzak = selectedзаказы;
            DataContext = _currenzak;
            ComboKlient.ItemsSource = КурсоваяEntities.GetContext().клиент.ToList();
            ComboTarif.ItemsSource = КурсоваяEntities.GetContext().тариф.ToList();
            ComboDiz.ItemsSource = КурсоваяEntities.GetContext().дизайн.ToList();
            Combooffice.ItemsSource = КурсоваяEntities.GetContext().офисы.ToList();
            Combooyslovia.ItemsSource = КурсоваяEntities.GetContext().условия_выпуска.ToList();
        }
        

        //private string GenerateNumber()
        //{
        //    string prefix = new List<string> { "404862", "404863", "407564", "406767", "404890", "412519", "423169", "510453", "512423", "522231" }[new Random().Next(0, 3)];
        //    string generatedNumber = prefix;

        //    while (generatedNumber.Length < 16)
        //    {
        //        generatedNumber += new Random().Next(0, 10);
        //    }

        //    return generatedNumber;
        //}
        //private bool IsCardExists(string accountNumber)
        //{
        //    return курсоваяEntities.GetContext().карты.Any(s => s.номер_карты == accountNumber);
        //}


        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            
            if (ComboKlient.SelectedItem == null) errors.AppendLine("Выберите клиента");
            if (ComboTarif.SelectedItem == null) errors.AppendLine("Выберите тариф");
            if (ComboDiz.SelectedItem == null) errors.AppendLine("Выберите дизайн");
            if (Combooffice.SelectedItem == null) errors.AppendLine("Выберите офис");
            if (Combooyslovia.SelectedItem == null) errors.AppendLine("Выберите условия");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            
            var maxId = КурсоваяEntities.GetContext().Заказы.Max(item => item.id);
            if (_currenzak.id == 0)
            {
                _currenzak.id = maxId + 1;
            }
            else
            {
                var zakaz = КурсоваяEntities.GetContext().Заказы.Where(c => c.id == _currenzak.id).FirstOrDefault();


                zakaz.тариф_id = (ComboTarif.SelectedItem as тариф)?.id;
                zakaz.дизайн_id = (ComboDiz.SelectedItem as дизайн)?.id;
                КурсоваяEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех");
                return;
            }
            //string generatedNumber = GenerateNumber();

            //_currenzak.номер_карты = generatedNumber;

            _currenzak.тариф_id = (ComboTarif.SelectedItem as тариф)?.id;
            _currenzak.дизайн_id = (ComboDiz.SelectedItem as дизайн)?.id;





            //_currenzak.номер_карты = generatedNumber;
            КурсоваяEntities.GetContext().Заказы.Add(_currenzak);
            КурсоваяEntities.GetContext().SaveChanges();


        }
    }
}
