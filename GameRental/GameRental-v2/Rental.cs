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
    public partial class Rental : Form
    {
        public Rental()
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
        private void fillcombo()
        {
            Con.Open();
            string query = "select Gid from Game where Available='"+"Yes"+"'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Gid", typeof(string));
            dt.Load(rdr);
            Gidd.ValueMember = "Gid";
            Gidd.DataSource = dt;
            Con.Close();
        }
        private void fillclient()
        {
            Con.Open();
            string query = "select Id from Client";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Load(rdr);
            Clname.ValueMember = "Id";
            Clname.DataSource = dt;
            Con.Close();
        }
        private void fetchClient()
        {
            Con.Open();
            string query = "select * from Client where Id=" + Clname.SelectedValue.ToString() + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            /*foreach (DataRow dr in dt.Rows)
            {
                Ganame.Text = dr["Cname"].ToString();
            }*/
            Con.Close();
        }
        private void UpdateonRent()
        {
                Con.Open();
                string query = "update Game set Available='" + "No" + "' where Gid =" + Gidd.SelectedValue.ToString() + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
               // MessageBox.Show("Game Updated successfuly");
                Con.Close();
            }
        private void UpdateonRentDelete()
        {
            Con.Open();
            string query = "update Game set Available='" + "Yes" + "' where Gid =" + Gidd.SelectedValue.ToString() + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            // MessageBox.Show("Game Updated successfuly");
            Con.Close();
        }
        private void Rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillclient();
            populate();
        }

        private void Cname_TextChanged(object sender, EventArgs e)
        {
            fetchClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( Gidd.Text == "" )
            {
                MessageBox.Show("Missing Info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Rental (Gid,Cname,RentDate,ReturnDate,RentFee)values('"+ Gidd.SelectedItem.ToString() + "','"+ Clname.SelectedItem.ToString() + "','" + Rentdate.Text + "','" + ReturnDate.Text + "','"+Fees.Text+ "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Game Rented successfuly");
                    Con.Close();
                    UpdateonRent();
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
                    string query = "delete from Game where Gid=" + Gidd.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Game Deleted succesfuly");
                    Con.Close();
                    populate();
                    UpdateonRentDelete();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RentId.Text = RentDGV.SelectedRows[0].Cells[0].Value.ToString();
            Gidd.Text = RentDGV.SelectedRows[0].Cells[1].Value.ToString();
           // Ganame.Text = RentDGV.SelectedRows[0].Cells[2].Value.ToString();
            Rentdate.Text = RentDGV.SelectedRows[0].Cells[3].Value.ToString();
            ReturnDate.Text = RentDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Gidd.Text == "" )
            {
                MessageBox.Show("Missing Info");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "UPDATE Rental SET Gid='" + Gidd.Text + "' ,Cname='" + Clname.Text + "'; ";
                    SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                    sda.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully");
                    Con.Close();
                    //UpdateonRent();
                    //populate();
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
