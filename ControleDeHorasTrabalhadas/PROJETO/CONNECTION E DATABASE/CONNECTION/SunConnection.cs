using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class SunConnection
    {
        public MySqlConnection Create()
        {

            //string connectionString = "server=localhost;database=SundownDB;uid=root;pwd=1234;Max Pool Size=500;";
            string connectionString = "server=us-cdbr-east-04.cleardb.com;database=heroku_b7763e0b07aa9ba;uid=b4fb09ce2b5b40;pwd=fc18a917;Max Pool Size=500;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            return connection;
        }
    }
}
