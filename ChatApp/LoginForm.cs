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
    public partial class LoginForm : Form
    {
        
        public LoginForm()
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
                    MessageForm frm = new MessageForm();
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

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            EntityPerson ent = new EntityPerson();
            if (int.TryParse(MskRgsNo.Text,out int Kayitno))
            {
                ent.Ad = TxtRgsAd.Text;
                ent.Soyad = TxtRgsSoyad.Text;
                ent.Sifre = TxtRgsSif.Text;
                ent.Numara = Kayitno;
                int result=LogicPerson.LLKayitol(ent);
                if (result>0)
                {
                    MessageBox.Show("Kaydınız oluşturuldu", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result==0)
                {
                    MessageBox.Show("Kayıt sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Boş hücre bırakmayınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Boş hücre bırakmayınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
