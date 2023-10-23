using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using LogicLayer;
using MaterialSkin.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatApp
{
    public partial class GirisForm : Form
    {
        
        public GirisForm()
        {
            InitializeComponent();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pnlorta.Left += 20;
            if (pnlorta.Left==300)
            {
                timer1.Stop();
                panel2.BackColor = Color.MediumPurple;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pnlorta.Left -= 20;
            if (pnlorta.Left == 0)
            {
                timer2.Stop();
                panel1.BackColor = Color.HotPink;
            }
        }

        private void LblLogin_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.HotPink;
            timer2.Start();          
        }

        private void LblRegister_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.MediumPurple;
            timer1.Start();          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            if (int.TryParse(MskLgnNo.Text, out int LgnNo))
            {
                List<EntityPerson> KullaniciGetir = LogicPerson.LLGirisYap(LgnNo, TxtLgnSif.Text);
                if (KullaniciGetir != null && KullaniciGetir.Count > 0)
                {
                    MesajForm frm = new MesajForm();
                    frm.UyeNo = LgnNo;
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı girişi yaptınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı girişi yaptınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
