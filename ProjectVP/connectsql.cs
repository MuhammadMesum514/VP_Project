using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVP
{
    class connectsql
    {
        public SqlConnection connect;

        public void connectdb()
        {
            connect= new SqlConnection(@"Data Source=SAM\SQLDEVELOPER;Initial Catalog=VaccinationSystem;Integrated Security=True;MultipleActiveResultSets=True;");
        }
}
}
