using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eczane_Otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string eczane_isim;

        //Anasayfadaki yönlendirlemerin oldugu butonların kısmı
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = eczane_isim + " ECZANESİ";
            //fatura fatura_ekran = new fatura();
           // fatura_ekran.eczane_isim = label1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ilac_liste ilac_listele = new ilac_liste();
            ilac_listele.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hasta_kayit hkf = new hasta_kayit();
            hkf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ilac_kayit ikf = new ilac_kayit();
            ikf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            recete receteli_satis = new recete();
            receteli_satis.Show();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            firma_bilgiler firma_bilgi = new firma_bilgiler();
            firma_bilgi.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hasta_liste hasta_listele = new hasta_liste();
            hasta_listele.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            firma_ekle firma_kaydet = new firma_ekle();
            firma_kaydet.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            recetesiz recetesiz_satis = new recetesiz();
            recetesiz_satis.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
