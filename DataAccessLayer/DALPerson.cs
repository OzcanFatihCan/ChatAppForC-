using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALPerson
    {
        public static List<EntityPerson> GirisYap(int No, string Pasw)
        {
            List<EntityPerson> UyeGirisi = new List<EntityPerson>();
            SqlCommand komut = new SqlCommand("Select * From TBLKISILER Where NUMARA=@p1 and SIFRE=@p2", Baglanti.conn);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", No);
            komut.Parameters.AddWithValue("@p2", Pasw);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityPerson ent = new EntityPerson();
                ent.Numara = int.Parse(dr["NUMARA"].ToString());
                ent.Sifre = dr["SIFRE"].ToString();
                UyeGirisi.Add(ent);
            }
            dr.Close();

            return UyeGirisi;
        }
    }
}
