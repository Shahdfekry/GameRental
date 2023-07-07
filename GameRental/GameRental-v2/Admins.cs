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
    public partial class Admins : Form
    {
        public Admins()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-RO0R3RE;Initial Catalog=Game_Rental;Integrated Security=True");
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from Admin";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
            da.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Uid.Text == "" || Fname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Missing Info");            
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Admin(AdminID,Fname,Lname,pass) values(" + Uid.Text + ",'" + Fname.Text + "','" + Lname.Text + "','" + Upass.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin added successfuly");
                    Con.Close();
                    populate();
                }catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
      
        private void button3_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "" || Fname.Text == "")
            {
                MessageBox.Show("Missing info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Admin where AdminID=" + Uid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin Deleted succesfuly");
                    Con.Close();
                    populate();
                }catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Uid.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            Fname.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            Lname.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            Upass.Text = UserDGV.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "" || Fname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Missing Info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Admin set Fname='" + Fname.Text + "',Lname='" + Lname.Text + "',pass='" + Upass.Text + "' where AdminID =" + Uid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin Updated successfuly");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Admins_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
