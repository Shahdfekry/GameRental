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
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-RO0R3RE;Initial Catalog=Game_Rental;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from Client";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            GameDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Cid.Text == "" || CFname.Text == "" || Address.Text == "" || Cphone.Text == "")
            {
                MessageBox.Show("Missing Info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Client values(" + Cid.Text + ",'" + CFname.Text + "','" +Address.Text + "','" + Sex.SelectedItem + "','" + Cphone.Text + "','" + CLname.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client added successfuly");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Cid.Text == "" || CFname.Text == "" || Address.Text == "" || Cphone.Text == "")
            {
                MessageBox.Show("Missing Info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Client set Fname='" + CFname.Text + "',Lname='" + CLname.Text + "',Phone='" + Cphone.Text + "',Address='" + Address.Text + "',Sex='" + Sex.SelectedItem + "' where Id =" + Cid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client Updated successfuly");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Cid.Text == "")
            {
                MessageBox.Show("Missing info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Client where Id=" + Cid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client Deleted succesfuly");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void GameDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cid.Text = GameDGV.SelectedRows[0].Cells[0].Value.ToString();
            CFname.Text = GameDGV.SelectedRows[0].Cells[1].Value.ToString();
            CLname.Text = GameDGV.SelectedRows[0].Cells[1].Value.ToString();
            Sex.SelectedItem = GameDGV.SelectedRows[0].Cells[1].Value.ToString();
            Cphone.Text = GameDGV.SelectedRows[0].Cells[2].Value.ToString();
            Address.Text = GameDGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
