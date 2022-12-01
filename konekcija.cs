using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace EsDnevnik2022A
{
    class konekcija
    {
        public static SqlConnection connect()
        {
            SqlConnection veza = new SqlConnection("Data Source=INF_4_PROFESOR\\SQLPBG;Initial Catalog=ednevnik2022;Integrated Security=true");
            return veza;
        }
            
    }
}
