using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_System
{
    public partial class DashBord : Form
    {
        public DashBord()
        {
            InitializeComponent();
        }



        ConnectionString MyConnection = new ConnectionString();
        
        private void DashBord_Load(object sender, EventArgs e)
        {
            MemberM.Value = 100;
            MemberD.Value = 100;

            SqlConnection Con = MyConnection.GetCon();
            Con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Add_Mem_Monthly",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label4.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter S = new SqlDataAdapter("select count(*) from Add_Mem_Daily", Con);
            DataTable D = new DataTable();
            S.Fill(D);
            label5.Text = D.Rows[0][0].ToString();

            Con.Close();



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main_Form mainform = new Main_Form();
            mainform.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
