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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-RO0R3RE;Initial Catalog=Game_Rental;Integrated Security=True");
       
        private void populate()
        {
            Con.Open();
            string query = "select * from Rental";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void UpdateonRent()
        {
            Con.Open();
            string query = "update Game set Available='" + "No" + "' where Gid =" + RentId.Text + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            // MessageBox.Show("Game Updated successfuly");
            Con.Close();
        }
        private void UpdateonRentDelete()
        {
            Con.Open();
            string query = "update Game set Available='" + "Yes" + "' where Gid =" + RentId.Text + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            // MessageBox.Show("Game Updated successfuly");
            Con.Close();
        }
        private void populateRet()
        {
            Con.Open();
            string query = "select * from Return";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void DeleteonReturn()
        {
            int rentId;
            rentId = Convert.ToInt32(RentDGV.SelectedRows[0].Cells[0].Value.ToString());
            Con.Open();
            string query = "delete from Rental where Rentid=" + RentId.Text + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("rental Deleted succesfuly");
            Con.Close();
            //UpdateonRentDelete();
            populate();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (RentId.Text == "" || ClientName.Text == "" || Fees.Text == "")
            {
                MessageBox.Show("Missing Info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Return values(" + RentId.Text + ",'" + GID.SelectedItem + ",'" + ClientName.Text  + "','" + ReturnDate.Text + "','" +Delay.Text + "','" + Fees.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Game Returned successfuly");
                    Con.Close();
                    //UpdateonRent();
                    populateRet();
                    DeleteonReturn();
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

        private void Return_Load(object sender, EventArgs e)
        {
            populate();
            populateRet();
        }

        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RentId.Text = RentDGV.SelectedRows[0].Cells[1].Value.ToString();
            ClientName.Text = RentDGV.SelectedRows[0].Cells[2].Value.ToString();
            ReturnDate.Text = RentDGV.SelectedRows[0].Cells[4].Value.ToString();
            DateTime d1 =ReturnDate.Value.Date;
            DateTime d2 =DateTime.Now;
            TimeSpan t = d2 - d1;
            int NumOfDays = Convert.ToInt32(t.TotalDays);
            if(NumOfDays <= 0)
            {
                Delay.Text = "0";
                Fees.Text = "No Fees";
            }
            else
            {
                Delay.Text = "" + NumOfDays;
                Fees.Text = "" + (NumOfDays * 250);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RentId.Text == "")
            {
                MessageBox.Show("Missing info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from GameTbl where Id=" + RentId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Game Deleted succesfuly");
                    Con.Close();
                    populate();
                    // UpdateonRentDelete();
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
    }
}
