using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameRental_v2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Games games = new Games();
            games.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clients clients = new Clients();
            clients.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admins admins = new Admins();
            admins.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return @return = new Return();
            @return.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rental rental = new Rental();
            rental.Show();
        }
    }
}
