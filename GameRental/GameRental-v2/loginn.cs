using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GameRental_v2
{
    public partial class loginn : Form
    {
        public loginn()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-RO0R3RE;Initial Catalog=Game_Rental;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select count(*) from Admin where AdminID = '" + UID.Text + "' and pass ='" + Upass.Text + "'";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MainForm mainform = new MainForm();
                mainform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or password");
            }
            Con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            UID.Text="";
            Upass.Text = "";
        }
    }
}
