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
    public partial class hasta_kayit : Form
    {
        public hasta_kayit()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RS972Q5;Initial Catalog=eczane_otomasyon;Integrated Security=True");

       
        private void hasta_kayit_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
                //olası durumda olusmayan degerler trydan cıkar catch kısmına gider.Catch bu hatayı yakalar ve hatayı yakalanan degerin sonucuna göre ne yazdırıldıysa onu ekrana bastırır.

            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Insert into hasta(hasta_tc,hasta_isim,hasta_soyisim,hasta_dogum,hasta_cinsiyet,hasta_adres,doktor_tc) Values ('" + Convert.ToInt64(textBox1.Text) + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + Convert.ToInt16(textBox4.Text) + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show(textBox2.Text+" Kişisi Kaydedildi..");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt Başarısız..");
            }
            
        }
    }
}
