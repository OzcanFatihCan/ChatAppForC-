using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityMessageSender
    {
        private string alici;
        private string baslik;
        private string icerik;

        public string Alici { get => alici; set => alici = value; }
        public string Baslik { get => baslik; set => baslik = value; }
        public string Icerik { get => icerik; set => icerik = value; }
    }
}
