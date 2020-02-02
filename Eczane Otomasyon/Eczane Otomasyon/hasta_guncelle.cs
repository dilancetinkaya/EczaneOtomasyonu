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
    public partial class hasta_guncelle : Form
    {
        public hasta_guncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RS972Q5;Initial Catalog=eczane_otomasyon;Integrated Security=True");
        public Int64 id = 0;
        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("Update hasta set hasta_tc='" + Convert.ToInt64(textBox1.Text) + "',hasta_isim='" + textBox2.Text.ToString() + "',hasta_soyisim='" + textBox3.Text.ToString() + "',hasta_dogum='" + Convert.ToInt16(textBox4.Text) + "',hasta_cinsiyet='" + textBox5.Text.ToString() + "',hasta_adres='" + textBox6.Text.ToString() + "',doktor_tc='" + textBox7.Text.ToString() + "'where hasta_tc =" + id + "", baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme Başarılı Bir Şekilde Gerçekleşti.");
                    baglan.Close();
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Güncelleme Başarılı Bir Şekilde Gerçekleştirilemedi.");
                }           
        }

        private void hasta_guncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasta_liste listele = new hasta_liste();
            listele.Show();
        }
    }
}
