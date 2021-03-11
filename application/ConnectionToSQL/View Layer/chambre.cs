using System;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConnectionToSQL.View_Layer
{


    public partial class chambre : Form
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public chambre()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            InitializeComponent();

            dataGridView1.Columns.Add("newColumnName", "Column Name in Text");
         
            // datagrid

            cmd = DBHelper.RunQuery("SELECT * FROM chambre group by noChambre;");

            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                int i =0;
                int previous = 0;
                int cptCell = 0;
                int biggest = -1; 

                foreach (DataRow dr in dt.Rows)
                {               
                    int x=Int32.Parse(dr["noChambre"].ToString())%100;
                    int y = Int32.Parse(dr["noChambre"].ToString()) - x;
                    y /= 100;
                    Console.WriteLine(dr["noChambre"]);
                    if (y!= previous)
                    {
                        cptCell = 0;
                        i =  dataGridView1.Rows.Add();
                        dataGridView1.Columns["newColumnName" ].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Rows[i].Cells[cptCell].Value = dr["noChambre"].ToString() ;                     
                    }
                    else
                    {
                        if (biggest < cptCell)
                        {
                            dataGridView1.Columns.Add("newColumnName" + cptCell, "Column Name in Text");
                           
                            biggest++;
                        }
                        dataGridView1.Columns["newColumnName" + cptCell].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        cptCell++;
                        dataGridView1.Rows[i].Cells[cptCell].Value = dr["noChambre"].ToString();                       
                    }
                    previous = y;
                }
            }
            else Console.WriteLine("null");
           // dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Raised;


            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;

            dataGridView1.ReadOnly = true;
           
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
   

        }

       
    }
}
