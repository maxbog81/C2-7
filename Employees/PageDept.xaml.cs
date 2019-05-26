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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для PageDept.xaml
    /// </summary>
    public partial class PageDept : Page
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;
        public PageDept()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);

            adapter = new SqlDataAdapter();

            #region select

            SqlCommand command =new SqlCommand("SELECT dept FROM Department order by dept", connection);
            adapter.SelectCommand = command;

            #endregion

            dt = new DataTable();

            adapter.Fill(dt);

            DeptDataGrid.DataContext = dt.DefaultView;
        }
    }
}
