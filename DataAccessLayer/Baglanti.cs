using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Baglanti
    {
        public static SqlConnection conn=new SqlConnection("Data Source=FatihBuzac\\SQLEXPRESS;Initial Catalog=DbChat;Integrated Security=True");
    }
}
