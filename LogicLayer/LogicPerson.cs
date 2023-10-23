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

        public static List<EntityPerson> LLBilgiGetr(int No)
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
    }
}
