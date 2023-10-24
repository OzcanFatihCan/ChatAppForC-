using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicPerson
    {
        public static List<EntityPerson> LLGirisYap(int No, string Sifre )
        {
            if (!string.IsNullOrEmpty(No.ToString()) &&
                Sifre!="")
            {
                return DALPerson.GirisYap(No,Sifre);
            }
            else
            {
                return null;
            }
        }

        public static List<EntityPerson> LLUyeGetir(int No)
        {
            if (!string.IsNullOrEmpty(No.ToString()))
            {
                return DALPerson.UyeGetir(No);
            }
            else
            {
                return null;
            }
        }

       public static int LLKayitol(EntityPerson ent)
        {
            if (!string.IsNullOrEmpty(ent.Numara.ToString()) &&
                ent.Ad != "" &&
                ent.Soyad != "" &&
                ent.Sifre != "")
            {
                return DALPerson.KayitOl(ent);
            }
            else
            {
                return -1;
            }
        }
        public static List<EntityPerson> LLNumaraGetir()
        {
            return DALPerson.NumaraGetir();
        }
    }
}
