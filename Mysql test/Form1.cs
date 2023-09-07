using ServiceStack.OrmLite;
using System;
using System.Windows.Forms;

namespace Mysql_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class LowercaseNamingStrategy : OrmLiteNamingStrategyBase
        {
            public override string GetTableName(string name)
            {
                return name.ToLower();
            }
        }

        private void Connect(string connectionString)
        {
            using (var db = DbCreation.Create(connectionString).Open())
            {
                string setcharset = "SET NAMES 'utf8'";
                var cmd = db.CreateCommand();
                cmd.CommandText = setcharset;
                cmd.ExecuteNonQuery();

                var cmd2 = db.CreateCommand();
                cmd2.CommandText = "Select max(id) from trackchanges";
                var lastId = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var connectionString = "TO_FILL!!!";
            Connect(connectionString);
        }
    }
}
