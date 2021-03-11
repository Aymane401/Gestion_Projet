using MySql.Data.MySqlClient;
using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ConnectionToSQL.Helper;


namespace ConnectionToSQL.DA_Layer
{
    public static class Querry
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static void CallQuerry(string query)
        {
            
            cmd = DBHelper.RunQuery(query);
            if (cmd != null)
            {
               

                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine("noChambre : " + dr["noChambre"].ToString() + " capacité : " + dr["capacité"].ToString() + " typec : " + dr["typec"].ToString());
                }
            }
            else Console.WriteLine("null");

        }
    }
}
