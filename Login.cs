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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        ConnectionString MyConnection = new ConnectionString();
        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection Con = MyConnection.GetCon();
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Sign_Up where Username='"+UsernameTb.Text+"'and Password='"+PasswordTb.Text+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Main_Form M = new Main_Form();
                M.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username Or Password");
            
            }
            Con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsernameTb.Text = "";
            PasswordTb.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
