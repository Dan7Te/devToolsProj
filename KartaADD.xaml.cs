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
using курсовая;

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для KartaADD.xaml
    /// </summary>
    public partial class KartaADD : Page
    {
        private клиент _currentUser = new клиент();
        private карты _currenKart = new карты();
        private счета _currenshet = new счета();
        public KartaADD(карты selectedкарты)
        {
            InitializeComponent();
            if (selectedкарты != null)
                _currenKart = selectedкарты;
            DataContext = _currenKart;
            ComboTarif.ItemsSource = КурсоваяEntities.GetContext().тариф.ToList();
            ComboDizain.ItemsSource = КурсоваяEntities.GetContext().дизайн.ToList();
            ComboStatys.ItemsSource = КурсоваяEntities.GetContext().статус_карты.ToList();
        }
        private string GenerateUniqueAccountNumber()
        {

            string accountNumber;
            // номер счета состоит из 10 цифр
            Random rnd = new Random();
            do
            {
                long accN1 = rnd.Next(10000, 99999);
                accN1 = accN1 << 32;
                long accN2 = rnd.Next(10000, 99999);
                long accountNumberInt = accN1 | accN2;
                accountNumber = accountNumberInt.ToString();
            } while (IsAccountExists(accountNumber));

            return accountNumber;
        }
        private bool IsAccountExists(string accountNumber)
        {
            return курсоваяEntities.GetContext().счета.Any(s => s.номер_счета == accountNumber);
        }
       
        private string GenerateNumber()
        {
            string prefix = new List<string> { "404862", "404863", "407564", "406767" ,"404890", "412519", "423169", "510453", "512423" , "522231" }[new Random().Next(0, 3)];
            string generatedNumber = prefix;

            while (generatedNumber.Length < 16)
            {
                generatedNumber += new Random().Next(0, 10);
            }

            return generatedNumber;
        }
        private bool IsCardExists(string accountNumber)
        {
            return КурсоваяEntities.GetContext().карты.Any(s => s.номер_карты == accountNumber);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
            if (string.IsNullOrWhiteSpace(srok.Text)) errors.AppendLine("Введите срок");
            if (string.IsNullOrWhiteSpace(nameKart.Text)) errors.AppendLine("Введите имя на карте");
            if (ComboKlient.SelectedItem == null) errors.AppendLine("Выберите клиента");
            if (ComboTarif.SelectedItem == null) errors.AppendLine("Выберите тариф");
            if (ComboDizain.SelectedItem == null) errors.AppendLine("Выберите дизайн");
            if (ComboStatys.SelectedItem == null) errors.AppendLine("Выберите статус готовности");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            var maxId = КурсоваяEntities.GetContext().карты.Max(item => item.id);
            if (_currenKart.id == 0)
            {
                _currenKart.id = maxId + 1;
            }
            else
            {
                var kart = КурсоваяEntities.GetContext().карты.Where(c => c.id == _currenKart.id).FirstOrDefault();
                
                kart.имя_на_карте = nameKart.Text;
                kart.тариф_id = (ComboTarif.SelectedItem as тариф)?.id;
                kart.дизайн_id = (ComboDizain.SelectedItem as дизайн)?.id;
                КурсоваяEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех");
                return;
            }





            //DateTime.TryParse(numberKart.Text, out DateTime dob);
            //if (DateTime.TryParse(numberKart.Text, out DateTime dob2))
            //{
            //    _currenKart.срок_действия = dob2;
            //}
            //else
            //{
            //    errors.AppendLine("Неверный формат даты рождения. Введите дату в подходящем формате.");
            //}
            _currenKart.имя_на_карте = nameKart.Text;
            //_currenKart.клиент_id = (ComboKlient.SelectedItem as клиент)?.id;
            _currenKart.тариф_id = (ComboTarif.SelectedItem as тариф)?.id;
            _currenKart.дизайн_id = (ComboDizain.SelectedItem as дизайн)?.id;
           // _currenKart.статус_карты = (ComboStatys.SelectedItem as статус_карты)?.id;





            string generatedAccountNumber = GenerateUniqueAccountNumber();

            _currenshet.номер_счета = generatedAccountNumber;
            _currenshet.валюта = "RUB";
            _currenshet.дата_открытия_счета = DateTime.Now;

            string generatedNumber = GenerateNumber();

            _currenKart.номер_карты = generatedNumber;
            

            if (IsAccountExists(generatedAccountNumber))
            {
                MessageBox.Show("Сгенерированный номер счета уже существует в базе данных. Повторите попытку.");
                return;
            }
            _currenKart.номер_счета = generatedAccountNumber;
            _currenKart.номер_карты = generatedNumber;
            КурсоваяEntities.GetContext().счета.Add(_currenshet);
            КурсоваяEntities.GetContext().карты.Add(_currenKart);
            КурсоваяEntities.GetContext().SaveChanges();


        }
    }
    
}


    