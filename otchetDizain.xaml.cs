using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для otchetDizain.xaml
    /// </summary>
    public partial class otchetDizain : Page
    {
        public otchetDizain()
        {
            InitializeComponent();
            string connectionString = "Server=LAPTOP-HHKOOILU\\SQLEXPRESS;Database=курсовая;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=true";
            string sqlQuery = @"
SELECT T.[дизайны], COUNT(Z.id) AS Количество 
FROM Заказы AS Z 
JOIN [дизайн] AS T ON Z.дизайн_id = T.Id 
GROUP BY T.[дизайны] 
ORDER BY Количество DESC;";
            List<DizInfo> DizainInfos = new List<DizInfo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string dizainName = reader.GetString(0);
                    int count = reader.GetInt32(1);
                    DizainInfos.Add(new DizInfo {  DizainName = dizainName, Count = count });
                }
            }

            // Удалить ограничение на первые 5 элементов
            // tarifInfos = tarifInfos.OrderByDescending(t => t.Count).ToList();

            // Присвоить список источнику данных для DataGrid
            datagridOtchetDiz.ItemsSource = DizainInfos;
        }

        // Класс для хранения информации о тарифе
        public class DizInfo
        {
            public string DizainName { get; set; }
            public int Count { get; set; }
        }
    }

        
}

