using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHorasTrabalhadas
{
    public class ProjetoDataBase
    {

        public void ExecuteInsert(string script)
        {
            SunConnection Storeconn = new SunConnection();
            MySqlConnection connection = Storeconn.Create();
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 20;

                command.CommandText = script;

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();

            }


        }

        public int ExecuteInsertInt(string script, List<MySqlParameter> parameters)
        {
            SunConnection Storeconn = new SunConnection();
            MySqlConnection connection = Storeconn.Create();

            MySqlCommand command = connection.CreateCommand();
            command.CommandTimeout = 20;

            command.CommandText = script;

            if (parameters != null)
            {
                foreach (MySqlParameter param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }


            command.ExecuteNonQuery();
            connection.Close();



            int id = Convert.ToInt32(command.LastInsertedId);

            return id;
        }

        public MySqlDataReader ExecuteSelect(string script)
        {

            SunConnection StoreConn = new SunConnection();
            MySqlConnection connection = StoreConn.Create();
            MySqlCommand command = connection.CreateCommand();
            command.CommandTimeout = 20;

            command.CommandText = script;

            MySqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return reader;

        }

        public void ExecuteInsertParamters(string script, List<MySqlParameter> parameters)
        {
            SunConnection Storeconn = new SunConnection();
            MySqlConnection connection = Storeconn.Create();
            try
            {


                MySqlCommand command = connection.CreateCommand();
                command.CommandTimeout = 20;

                command.CommandText = script;

                if (parameters != null)
                {
                    foreach (MySqlParameter param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                }


                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();

            }


        }


        public MySqlDataReader ExecuteSelectParamters(string script, List<MySqlParameter> parameters)
        {

            SunConnection StoreConn = new SunConnection();
            MySqlConnection connection = StoreConn.Create();
            MySqlCommand command = connection.CreateCommand();
            command.CommandTimeout = 20;

            command.CommandText = script;

            if (parameters != null)
            {
                foreach (MySqlParameter param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }

            MySqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return reader;

        }
    }
}
