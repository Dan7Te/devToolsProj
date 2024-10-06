using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для otchetTarif.xaml
    /// </summary>
    /// 
    public partial class otchetTarif : Page
    {
        public otchetTarif()
        {
            InitializeComponent();

            string connectionString = "Server=LAPTOP-HHKOOILU\\SQLEXPRESS;Database=курсовая;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=true";
            string sqlQuery = @"
SELECT T.[тарифы], COUNT(Z.id) AS Количество 
FROM Заказы AS Z 
JOIN [тариф] AS T ON Z.тариф_id = T.Id 
GROUP BY T.[тарифы] 
ORDER BY Количество DESC;";
            List<TarifInfo> tarifInfos = new List<TarifInfo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string tarifName = reader.GetString(0);
                    int count = reader.GetInt32(1);
                    tarifInfos.Add(new TarifInfo { TarifName = tarifName, Count = count });
                }
            }

            // Удалить ограничение на первые 5 элементов
            // tarifInfos = tarifInfos.OrderByDescending(t => t.Count).ToList();

            // Присвоить список источнику данных для DataGrid
            datagridOtchetTarif.ItemsSource = tarifInfos;
        }

        // Класс для хранения информации о тарифе
        public class TarifInfo
        {
            public string TarifName { get; set; }
            public int Count { get; set; }
        }

    }




}


       
    

