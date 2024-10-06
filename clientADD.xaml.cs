using Mysqlx;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для clientADD.xaml
    /// </summary>
    public partial class clientADD : Page
    {
        private клиент _currentUser = new клиент();
        private счета _currenshet = new счета();
        public clientADD(клиент selectedклиент)
        {
            InitializeComponent();
            if (selectedклиент != null )
                _currentUser = selectedклиент;
            DataContext = _currentUser;
            Combokategoria.ItemsSource = курсоваяEntities.GetContext().категория_клиента.ToList();
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
                long accountNumberInt = accN1|accN2;
                accountNumber = accountNumberInt.ToString();
            } while (IsAccountExists(accountNumber));

            return accountNumber;
        }
        private bool IsAccountExists(string accountNumber)
        {
            return КурсоваяEntities.GetContext().счета.Any(s => s.номер_счета == accountNumber);
        }
      
        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(fio.Text)) errors.AppendLine("Введите ФИО");
            if (string.IsNullOrWhiteSpace(date.Text)) errors.AppendLine("Введите дату рождения");
            if (string.IsNullOrWhiteSpace(gender.Text)) errors.AppendLine("Введите пол");
            if (string.IsNullOrWhiteSpace(adress.Text)) errors.AppendLine("Введите адрес проживания ");
            if (Combokategoria.SelectedItem == null) errors.AppendLine("Выберите категорию клиента");
             
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
           
            
            var maxId = КурсоваяEntities.GetContext().клиент.Max(item => item.id_клиента);
            if (_currentUser.id_клиента == 0)
            {
                _currentUser.id_клиента = maxId + 1;
            }
            else 
            {
                var client = КурсоваяEntities.GetContext().клиент.Where(c=> c.id_клиента == _currentUser.id_клиента).FirstOrDefault();
                client.фио = fio.Text;
                client.пол = gender.Text;
                client.адрес = adress.Text;
                client.категория_клиента_id = (Combokategoria.SelectedItem as категория_клиента)?.id;
                КурсоваяEntities.GetContext().SaveChanges();
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
           _currentUser.категория_клиента_id = (Combokategoria.SelectedItem as категория_клиента)?.id;



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

            КурсоваяEntities.GetContext().счета.Add(_currenshet);



            КурсоваяEntities.GetContext().клиент.Add(_currentUser);
            КурсоваяEntities.GetContext().SaveChanges();

            
        }
            
    }
        




}

