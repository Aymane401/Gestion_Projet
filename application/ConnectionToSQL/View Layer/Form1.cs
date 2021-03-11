using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ConnectionToSQL.DA_Layer;
using ConnectionToSQL;
using ConnectionToSQL.View_Layer;
using System.Windows.Forms;

namespace ConnectionToSQL
{
  

    public partial class Form1 : Form
    {
        private void openChildForm(Form childform)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            childPanel.Controls.Add(childform);
            childPanel.Tag = childform;
            childform.BringToFront();
            childform.Show();

        }


        //private static MySqlCommand cmd = null;
        //private static DataTable dt;
        //private static MySqlDataAdapter sda;
        public static Form1 form1 = new Form1();
       public static string temp;
        public string Label1   // property
        {
            set {
                temp = value;
            }
        }
    
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
    
            DBHelper.EstablishConnection(); // initialiser la connection avec la base mysql
            label1.Text = temp; // insérer si la conexion est réussite dans le label1
            if (temp == "Database connection successfull") label1.BackColor = System.Drawing.Color.Lime; 
            else label1.BackColor = System.Drawing.Color.Red;

            openChildForm(new Acceuil());

            // datagrid

            //cmd = DBHelper.RunQuery("SELECT * FROM abc.client;");



            //if (cmd != null)
            //{


            //    dt = new DataTable();
            //    sda = new MySqlDataAdapter(cmd);
            //    sda.Fill(dt);
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        int num = dataGridView1.Rows.Add();
            //        dataGridView1.Rows[num].Cells[0].Value = dr["noCli"].ToString();
            //        dataGridView1.Rows[num].Cells[1].Value = dr["nom"].ToString();
            //        dataGridView1.Rows[num].Cells[2].Value = dr["rue"].ToString();
            //        dataGridView1.Rows[num].Cells[3].Value = dr["ville"].ToString();

            //    }
            //}
            //else Console.WriteLine("null");



        }


        private void label1_Click_1(object sender, EventArgs e)
        {
            Querry.CallQuerry("SELECT * FROM chambre; ");

          

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Acceuil());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Reservations ());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new  chambre());
        }

        private Form activeform = null;
    
        private void childPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Parametres());
        }
    }
}
