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
    public partial class Games : Form
    {
        public Games()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-RO0R3RE;Initial Catalog=Game_Rental;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from Game";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            GameDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Gid.Text == "" || Gname.Text == "" || Gprice.Text == "")
            {
                MessageBox.Show("Missing Info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Game values(" + Gid.Text +",'"+ Gname.Text  +"','" + Gprice.Text + "','" +AvaliableCb.SelectedItem.ToString() + "','" + CategCb.SelectedItem.ToString() + "','" + Vendor.Text + "','" + Rating.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Game added successfuly");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void fillAvaliable()
        {
            Con.Open();
            string query = "select Available from Game";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Available", typeof(string));
            dt.Load(rdr);
            Search.ValueMember = "Available";
            Search.DataSource = dt;
            Con.Close();
        }

        private void Games_Load(object sender, EventArgs e)
        {
            populate();
            //fillAvaliable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Gid.Text == "")
            {
                MessageBox.Show("Missing info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Game where Gid=" + Gid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Game Deleted succesfuly");
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
            Gid.Text = GameDGV.SelectedRows[0].Cells[0].Value.ToString();
            Gname.Text = GameDGV.SelectedRows[0].Cells[1].Value.ToString();
            Gprice.Text = GameDGV.SelectedRows[0].Cells[2].Value.ToString();
            AvaliableCb.SelectedItem = GameDGV.SelectedRows[0].Cells[3].Value.ToString();
            CategCb.SelectedItem = GameDGV.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Gid.Text == "" || Gname.Text == "" || Gprice.Text == "")
            {
                MessageBox.Show("Missing Info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Game set Gname='" + Gname.Text + "',Gprice='" + Gprice.Text + "',Available='" + AvaliableCb.SelectedItem.ToString() + "',Categ='" + CategCb.SelectedItem.ToString() + "',vendor='" + Vendor.Text+ "',Rating='" + Rating.Text+ "' where Gid =" + Gid.Text + ";"; 
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Game Updated successfuly");
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

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string flag = "";
            if(Search.SelectedItem.ToString() == "Available")
            {
                flag = "Yes";
            }
            else
            {
                flag = "No";
            }
            Con.Open();
            string query = "select * from GAME where Available ='"+flag+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            GameDGV.DataSource = ds.Tables[0];
            Con.Close();*/
        }
    }
}
