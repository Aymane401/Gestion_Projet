using MySql.Data.MySqlClient;
using System;
using ConnectionToSQL.View_Layer;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;


namespace ConnectionToSQL
{
    public static class DBHelper 
    {
        private static MySqlConnection connection;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        
        public static void EstablishConnection()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "52.233.39.40";
                builder.UserID = "root";
                builder.Password = "toor";
                builder.Database = "hotel";
                builder.SslMode = MySqlSslMode.None;
                connection = new MySqlConnection(builder.ToString());


                connection.Open();
                Form1.form1.Label1 = "Database connection successfull";
               
               
                
            }
            catch (MySqlException ex)
            {
                Form1.form1.Label1 = "connection to database Failed";
                MessageBox.Show( ex.ToString() , "Connection to Database Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


      
        public static MySqlCommand RunQuery(string query)
        {
            try
            {
                if(connection != null)
                {
                    
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                connection.Close();
            }
            return cmd;
        }
    }
}
