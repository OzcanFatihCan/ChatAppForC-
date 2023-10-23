using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityPerson
    {
        private string ad;
        private string soyad;
        private int numara;
        private string sifre;

        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public int Numara { get => numara; set => numara = value; }
        public string Sifre { get => sifre; set => sifre = value; }
    }
}
