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


namespace Gym_Management_System
{
    public partial class Add_Mem_Day : Form
    {
        public Add_Mem_Day()
        {
            InitializeComponent();
        }

        private void filterByName()
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection Con = MyConnection.GetCon();
            Con.Open();
            string query = "select * from Add_Mem_Daily where Name_D like'%" + SearchMember.Text + "%'    ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];

            Con.Close();

        }
        void Populate()
        {
            Add_Mem_Days Amd = new Add_Mem_Days();
            string query = "select * from Add_Mem_Daily";


            DataSet ds = Amd.Show_Mem_Day(query);
            MemberSDGV.DataSource = ds.Tables[0];
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string query = "insert into Add_Mem_Daily values('" + NameD.Text + "','" + PhoneD.Text + "','" + AgeD.Text + "','" + GenderD.SelectedItem.ToString() + "','" + AmountD.Text + "','" + TimingD.SelectedItem.ToString() + "' ,'"+ PeriodeD.Value.Date+ "')";
            Add_Mem_Days Add = new Add_Mem_Days();
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
        int key = 0;
        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameD.Text = MemberSDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneD.Text = MemberSDGV.SelectedRows[0].Cells[2].Value.ToString();
            AgeD.Text = MemberSDGV.SelectedRows[0].Cells[3].Value.ToString();
            GenderD.Text = MemberSDGV.SelectedRows[0].Cells[4].Value.ToString();
            AmountD.Text = MemberSDGV.SelectedRows[0].Cells[5].Value.ToString();
            TimingD.Text = MemberSDGV.SelectedRows[0].Cells[6].Value.ToString();
            PeriodeD.Text = MemberSDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (NameD.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MemberSDGV.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void Add_Mem_Day_Load(object sender, EventArgs e)
        {

            Populate();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add_Mem_Days Amd = new Add_Mem_Days();
            if (key==0)
            {
                MessageBox.Show("Select The Member");
            }
            else 
            {
                try
                {
                    string query = "delete from Add_Mem_Daily where Id=" + key + "";

                    Amd.Delete_Mem_Day(query);
                    MessageBox.Show("The Member Successfully Deleted");
                    Populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message  );
                }

            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Mem_Days Amd = new Add_Mem_Days();
            if (key == 0)
            {
                MessageBox.Show("Select The Member");
            }
            else
            {
                try
                {
                    string query = "Update Add_Mem_Daily set Name_D='"+NameD.Text+"',Phone_D='"+PhoneD.Text+"',Age_D='"+AgeD.Text+"',Gender_D='"+GenderD.SelectedItem.ToString() + "',Monthiy_Amount_D='"+AmountD+"',Timing_D='"+TimingD.SelectedItem.ToString() + "' ,Date_D='"+ PeriodeD.Value.Date + "'  where Id="+key+" ";

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

        private void button4_Click(object sender, EventArgs e)
        {
            Main_Form mainform = new Main_Form();
            mainform.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameD.Text = "";
            PhoneD.Text = "";
            AgeD.Text = "";
            GenderD.Text = "";
            AmountD.Text = "";
            TimingD.Text = "";
        }

        private void SearchMember_TextChanged(object sender, EventArgs e)
        {
            filterByName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
