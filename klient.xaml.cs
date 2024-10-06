using Mysqlx;
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
    /// Логика взаимодействия для klient.xaml
    /// </summary>
    public partial class klient : Page
    {
        private клиент _currentUser = new клиент();
        private Заказы _newOrder = new Заказы();
        private счета _currenshet = new счета();
       
        public klient()
        {
            InitializeComponent();
            Combotarif.ItemsSource = курсоваяEntities.GetContext().тариф.ToList();
            Combospisokdizain.ItemsSource = курсоваяEntities.GetContext().дизайн.ToList();
            Combooffice.ItemsSource = курсоваяEntities.GetContext().офисы.ToList();
            ComboYslovia.ItemsSource = курсоваяEntities.GetContext().условия_выпуска.ToList();
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

        


        private void zakaz_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(fio.Text)) errors.AppendLine("Введите ФИО");
            if (string.IsNullOrWhiteSpace(date.Text)) errors.AppendLine("Введите дату рождения");
            if (string.IsNullOrWhiteSpace(gender.Text)) errors.AppendLine("Введите пол");
            if (string.IsNullOrWhiteSpace(adress.Text)) errors.AppendLine("Введите адрес проживания ");
            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            var maxId = курсоваяEntities.GetContext().клиент.Max(item => item.id_клиента);
            if (_currentUser.id_клиента == 0)
            {
                _currentUser.id_клиента = maxId + 1;
            }
            else
            {
                var client = курсоваяEntities.GetContext().клиент.Where(c => c.id_клиента == _currentUser.id_клиента).FirstOrDefault();
                client.фио = fio.Text;
                client.пол = gender.Text;
                client.адрес = adress.Text;
                
                курсоваяEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех");
                return;
            }
            DateTime.TryParse(date.Text, out DateTime dob);
            if (DateTime.TryParse(date.Text, out DateTime dob2))
            {
                _currentUser.дата_рождения = dob2;
            }
            else
            {
                errors.AppendLine("Неверный формат даты рождения. Введите дату в подходящем формате.");
            }
            _currentUser.фио = fio.Text;
            _currentUser.пол = gender.Text;
            _currentUser.адрес = adress.Text;

            string generatedAccountNumber = GenerateUniqueAccountNumber();

            _currenshet.номер_счета = generatedAccountNumber;
            _currenshet.валюта = "RUB";
            _currenshet.дата_открытия_счета = DateTime.Now;

            



            if (IsAccountExists(generatedAccountNumber))
            {
                MessageBox.Show("Сгенерированный номер счета уже существует в базе данных. Повторите попытку.");
                return;
            }
            _currentUser.номер_счета = generatedAccountNumber;

            курсоваяEntities.GetContext().счета.Add(_currenshet);
            курсоваяEntities.GetContext().клиент.Add(_currentUser);
            _newOrder.клиент_id = _currentUser.id_клиента;

            
            if (Combotarif.SelectedItem == null) errors.AppendLine("Выберите тариф");
            if (Combospisokdizain.SelectedItem == null) errors.AppendLine("Выберите дизайн");
            if (Combooffice.SelectedItem == null) errors.AppendLine("Выберите офис");
            if (ComboYslovia.SelectedItem == null) errors.AppendLine("Выберите условия");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }



            var mxId = курсоваяEntities.GetContext().Заказы.Max(item => item.id);
            if (_newOrder.id == 0)
            {
                _newOrder.id = mxId + 1;
            }
            else
            {
                var zakaz = курсоваяEntities.GetContext().Заказы.Where(c => c.id == _newOrder.id).FirstOrDefault();


                zakaz.тариф_id = (Combotarif.SelectedItem as тариф)?.id;
                zakaz.дизайн_id = (Combospisokdizain.SelectedItem as дизайн)?.id;
                zakaz.офисы_id = (Combooffice.SelectedItem as офисы)?.id;
                zakaz.условия_выпуска_id = (ComboYslovia.SelectedItem as условия_выпуска)?.id;
                курсоваяEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех");
                return;
            }
            _newOrder.тариф_id = (Combotarif.SelectedItem as тариф)?.id;
            _newOrder.дизайн_id = (Combospisokdizain.SelectedItem as дизайн)?.id;
            _newOrder.офисы_id = (Combooffice.SelectedItem as офисы)?.id;
            _newOrder.условия_выпуска_id = (ComboYslovia.SelectedItem as условия_выпуска)?.id;
            курсоваяEntities.GetContext().Заказы.Add(_newOrder);
            курсоваяEntities.GetContext().SaveChanges();
        }


}
           
    
    
}
           

   

        
    