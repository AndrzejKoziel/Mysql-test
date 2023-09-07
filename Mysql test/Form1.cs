using ServiceStack.OrmLite;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Mysql_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectWebLegacy(string connectionString)
        {
                using (var db = DbCreation.Create(connectionString).Open())
                {
                    string setcharset = "SET NAMES 'utf8'";
                    var cmd = db.CreateCommand();
                    cmd.CommandText = setcharset;
                    cmd.ExecuteNonQuery();

                    var cmd2 = db.CreateCommand();
                    cmd2.CommandText = "Select max(id) from trackedchanges";
                    var lastId = Convert.ToInt32(cmd2.ExecuteScalar());
                }
        }

        private void ConnectMySqlData(string connectionString)
        {
            MySqlConnection conn;

                using (conn = new MySqlConnection())
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();

                    var cmd2 = conn.CreateCommand();
                    cmd2.CommandText = "Select max(id) from trackedchanges";
                    var lastId = Convert.ToInt32(cmd2.ExecuteScalar());
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var connectionString = "TO_FILL!!!";

            //ConnectWebLegacy(connectionString);
            ConnectMySqlData(connectionString);
        }
    }
}
