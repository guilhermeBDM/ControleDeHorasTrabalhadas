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
            //string connectionString = "server=13.84.146.122;database=sundownDB;uid=sundown;pwd=sundowntcc2k;Max Pool Size=500";
            //string connectionString = "server=localhost;database=duarteDB;uid=duarte;pwd=1234;Max Pool Size=500";
            string connectionString = "server=localhost;database=SundownDB;uid=root;pwd=1234;Max Pool Size=500;";


            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            return connection;
        }
    }
}
