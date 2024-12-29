using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management_System
{
    class ConnectionString
    {

        public SqlConnection GetCon()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Gym_Management_Db;Integrated Security=True";
            return Con;

        }


    }
}
