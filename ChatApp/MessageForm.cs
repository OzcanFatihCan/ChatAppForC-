using EntityLayer;
using LogicLayer;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class MessageForm : Form
    {
        public int UyeNo;
        public MessageForm()
        {
            InitializeComponent();          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void GelenKutusu(int Alici)
        {
            List<EntityMessageReceiver> Mesaj = LogicMessage.LLMesajGetir(Alici);
            dataGridView1.DataSource= Mesaj;
        }
        void GidenKutusu(int Gonderen)
        {
            List<EntityMessageSender> Mesaj = LogicMessage.LLMesajGiden(Gonderen);
            dataGridView2.DataSource = Mesaj;
        }

        private void MesajForm_Load(object sender, EventArgs e)
        {
            LblNumara.Text = Convert.ToString(UyeNo);

            //üye çek
            List<EntityPerson> BilgiGetir = LogicPerson.LLBilgiGetr(UyeNo);
            foreach (var item in BilgiGetir)
            {
                LblAdSoyad.Text = item.Ad + " " + item.Soyad;
            }
            GelenKutusu(UyeNo);
            GidenKutusu(UyeNo);
        }
    }
}
