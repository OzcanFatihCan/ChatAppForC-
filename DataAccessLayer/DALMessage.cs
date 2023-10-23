using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALMessage
    {
        public static List<EntityMessageReceiver> MesajGetir(int alici)
        {
            List<EntityMessageReceiver> Mesajlar=new List<EntityMessageReceiver>();
            SqlCommand komut = new SqlCommand("Select * From TBLMESAJLAR Where ALICI=@p1", Baglanti.conn);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1",alici);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                EntityMessageReceiver msg = new EntityMessageReceiver();
                msg.Icerik = dr["ICERIK"].ToString();
                msg.Gonderen = int.Parse(dr["GONDEREN"].ToString());
                msg.Baslik = dr["BASLIK"].ToString();
                Mesajlar.Add(msg);
            }
            dr.Close();
            return Mesajlar;
        }

        public static List<EntityMessageSender> MesajGiden(int Gonderen)
        {
            List<EntityMessageSender> Mesajlar = new List<EntityMessageSender>();
            SqlCommand komut = new SqlCommand("Select * From TBLMESAJLAR Where GONDEREN=@p1", Baglanti.conn);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", Gonderen);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityMessageSender msg = new EntityMessageSender();
                msg.Icerik = dr["ICERIK"].ToString();
                msg.Alici = int.Parse(dr["ALICI"].ToString());
                msg.Baslik = dr["BASLIK"].ToString();
                Mesajlar.Add(msg);
            }
            dr.Close();
            return Mesajlar;
        }

        public static int MesajGonder(EntityMessage ent)
        {
            SqlCommand komut2 = new SqlCommand("INSERT INTO TBLMESAJLAR (ALICI,BASLIK,ICERIK,GONDEREN) VALUES (@P1,@P2,@P3,@P4)",Baglanti.conn);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1",ent.Alici);
            komut2.Parameters.AddWithValue("@P2", ent.Baslik);
            komut2.Parameters.AddWithValue("@P3", ent.Icerik);
            komut2.Parameters.AddWithValue("@P4", ent.Gonderen);

            return komut2.ExecuteNonQuery();
        }
    }
}
