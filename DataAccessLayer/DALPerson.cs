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
        public static List<EntityPerson> UyeGetir(int No)
        {
            List<EntityPerson> UyeBilgileri = new List<EntityPerson>();
            SqlCommand komut2 = new SqlCommand("Select AD,SOYAD From TBLKISILER Where NUMARA=@p1", Baglanti.conn);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1", No);
            SqlDataReader dr1 = komut2.ExecuteReader();
            while (dr1.Read())
            {
                EntityPerson ent=new EntityPerson();
                ent.Ad = dr1["AD"].ToString();
                ent.Soyad = dr1["SOYAD"].ToString();
                UyeBilgileri.Add(ent);
            }
            dr1.Close();
            return UyeBilgileri;
        }
    }
}
