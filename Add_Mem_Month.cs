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
    public partial class Add_Mem_Month : Form
    {
        public Add_Mem_Month()
        {
            InitializeComponent();
        }
        void Populate()
        {
            Add_Mem_Months Amd = new Add_Mem_Months();
            string query = "select * from Add_Mem_Monthly";


            DataSet ds = Amd.Show_Mem_Day(query);
            MemberDGV.DataSource = ds.Tables[0];
        }
       int key = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void filterByName()
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection Con = MyConnection.GetCon();
            Con.Open();
            string query = "select * from Add_Mem_Monthly where Name like'%" + SearchMember.Text + "%'    ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberDGV.DataSource = ds.Tables[0];

            Con.Close();

        }
        private void SearchMember_TextChanged(object sender, EventArgs e)
        {
            filterByName();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameM.Text = MemberDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneM.Text = MemberDGV.SelectedRows[0].Cells[2].Value.ToString();
            AgeM.Text = MemberDGV.SelectedRows[0].Cells[3].Value.ToString();
            GenderM.Text = MemberDGV.SelectedRows[0].Cells[4].Value.ToString();
            AmountM.Text = MemberDGV.SelectedRows[0].Cells[5].Value.ToString();
            TimingM.Text = MemberDGV.SelectedRows[0].Cells[6].Value.ToString();
            PeriodeMS.Text = MemberDGV.SelectedRows[0].Cells[7].Value.ToString();
            dateTimeME.Text = MemberDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (NameM.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MemberDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "insert into Add_Mem_Monthly values('" + NameM.Text + "','" + PhoneM.Text + "','" + AgeM.Text + "','" + GenderM.SelectedItem.ToString() + "','" + AmountM.Text + "','" + TimingM.SelectedItem.ToString() + "' ,'" + PeriodeMS.Value.Date + "','" + dateTimeME.Value.Date + "')";
            Add_Mem_Months Add = new Add_Mem_Months();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Mem_Months Amd = new Add_Mem_Months();
            if (key == 0)
            {
                MessageBox.Show("Select The Member");
            }
            else
            {
                try
                {
                    string query = "Update Add_Mem_Monthly set Name='" + NameM.Text + "',Phone='" + PhoneM.Text + "',Age='" + AgeM.Text + "',Gender='" + GenderM.SelectedItem.ToString() + "',Monthly_Amount='" + AmountM + "',Timing='" + TimingM.SelectedItem.ToString() + "' ,Start_Date='" + PeriodeMS.Value.Date + "',End_Date='"+ dateTimeME.Value.Date + "'  where Id=" + key + " ";

                    Amd.Update_Mem_Day(query);
                    MessageBox.Show("The Member Successfully Updated");
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
            Add_Mem_Months Amd = new Add_Mem_Months();
            if (key == 0)
            {
                MessageBox.Show("Select The Member");
            }
            else
            {
                try
                {
                    string query = "delete from Add_Mem_Monthly where Id=" + key + "";

                    Amd.Delete_Mem_Day(query);
                    MessageBox.Show("The Member Successfully Deleted");
                    Populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameM.Text = "";
            PhoneM.Text = "";
            AgeM.Text = "";
            GenderM.Text = "";
            AmountM.Text = "";
            TimingM.Text = "";
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
