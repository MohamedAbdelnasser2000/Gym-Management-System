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
    public partial class Sign_Up : Form
    {
        public Sign_Up()
        {
            InitializeComponent();
        }
        int key = 0;

        
        void Populate()
        {
            Sign_Ups Amd = new Sign_Ups();
            string query = "select * from Sign_Up";


            DataSet ds = Amd.Show_Mem_Day(query);
            MemberSDGV.DataSource = ds.Tables[0];
        }
        
        private void Sign_Up_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsernameTb.Text = "";
            PasswordTb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "insert into Sign_Up values('" + UsernameTb.Text + "','" + PasswordTb.Text + "')";
            Sign_Ups Add = new Sign_Ups();
            try
            {
                Add.Add_Mem_Day(query);
                MessageBox.Show("The Member Successfully Added");
                Populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UsernameTb.Text = MemberSDGV.SelectedRows[0].Cells[1].Value.ToString();
            PasswordTb.Text = MemberSDGV.SelectedRows[0].Cells[2].Value.ToString();
             if (UsernameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MemberSDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sign_Ups Amd = new Sign_Ups();
            if (key == 0)
            {
                MessageBox.Show("Select The Username and Password");
            }
            else
            {
                try
                {
                    string query = "Update Sign_Up set Username='" + UsernameTb.Text + "',Password='" + PasswordTb.Text + "'  where U_Id=" + key + " ";

                    Amd.Update_Mem_Day(query);
                    MessageBox.Show("The Username And Password Successfully Updated");
                    Populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Sign_Ups Amd = new Sign_Ups();
            if (key == 0)
            {
                MessageBox.Show("Select The Member");
            }
            else
            {
                try
                {
                    string query = "delete from Sign_Up where U_Id=" + key + "";

                    Amd.Delete_Mem_Day(query);
                    MessageBox.Show("The Username And Password Successfully Deleted");
                    Populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main_Form mainform = new Main_Form();
            mainform.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
