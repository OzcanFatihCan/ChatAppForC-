using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicMessage
    {
        public static List<EntityMessageReceiver> LLMesajGetir(int Alici)
        {
            if (!string.IsNullOrEmpty(Alici.ToString()))
            {
                return DALMessage.MesajGetir(Alici);
            }
            else
            {
                return null;
            }
        }

        public static List<EntityMessageSender> LLMesajGiden(int Gonderen)
        {
            if (!string.IsNullOrEmpty(Gonderen.ToString()))
            {
                return DALMessage.MesajGiden(Gonderen);
            }
            else
            {
                return null;
            }
        }
    }
}
