using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eczane_Otomasyon
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RS972Q5;Initial Catalog=eczane_otomasyon;Integrated Security=True");

        String[] eczane_isimler;
        String[] sifre;
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < eczane_isimler.Length; i++)
            {
                if(textBox1.Text==eczane_isimler[i] && textBox2.Text == sifre[i])
                {
                    Form1 form = new Form1();
                    this.Hide();
                    form.eczane_isim = eczane_isimler[i];
                    form.Show();
                    
                }
            }
        }

        private void giris_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from kullanıcı_tablosu ", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            int i = 0;
            eczane_isimler = new String[100];
            sifre = new String[100];
            while (oku.Read())
            {
                
                string[] isim_bolme = oku["eczane_isim"].ToString().Split(' ');//kullanıcı adı ve sifreleri split sayesinde kontrol ediyoruz.
                string[] sifre_bolme = oku["sifre"].ToString().Split(' ');
                eczane_isimler[i] = isim_bolme[0];
                sifre[i] = sifre_bolme[0];
                i++;
            }
            baglan.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
