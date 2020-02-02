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
    public partial class recete : Form
    {
        public recete()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RS972Q5;Initial Catalog=eczane_otomasyon;Integrated Security=True");

        public void saat()
        {
            DateTime dt = DateTime.Now;
            int gün = dt.Day;
            int ay = dt.Month;
            int yil = dt.Year;
            int saat = dt.Hour;
            int dakika = dt.Minute;

            if (gün < 10)
            {
                if (ay < 10)
                {
                    label14.Text = ("0" + gün + ".0" + ay + "." + yil).ToString();
                }
                else
                {
                    label14.Text = ("0" + gün + "." + ay + "." + yil).ToString();
                }
            }
            else
            {
                if (ay < 10)
                {
                    label14.Text = (gün + ".0" + ay + "." + yil).ToString();
                }
                else
                {
                    label14.Text = (gün + "." + ay + "." + yil).ToString();
                }
            }


            if (saat < 10)
            {
                if (dakika < 10)
                {
                    label15.Text = ("0" + saat + ":0" + dakika).ToString();
                }
                else
                {
                    label15.Text = ("0" + saat + ":" + dakika).ToString();
                }
            }
            else
            {
                if (dakika < 10)
                {
                    label15.Text = (saat + ":0" + dakika).ToString();
                }
                else
                {
                    label15.Text = (saat + ":" + dakika).ToString();
                }
            }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Count() == 11)
            {
                button1.Enabled = true;
            }else
            {
                button1.Enabled = false;
            }
        }

        private void recete_Load(object sender, EventArgs e)
        {
            saat();
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saat();
        }
        int recete_id;

        public void recete_sorgulama(String sutun,String arama)
        {
            try{
                SqlCommand komut = new SqlCommand("SELECT * FROM recete R INNER JOIN receteid_ilacisim Ri ON R.recete_id = Ri.recete_id WHERE " + sutun + " =" + Convert.ToInt64(arama), baglan);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    recete_id = Convert.ToInt16(oku["recete_id"]);
                    ekle.Text = recete_id.ToString();
                    ekle.SubItems.Add(oku["tarih"].ToString());
                    ekle.SubItems.Add(oku["ilac_isim"].ToString());
                    ekle.SubItems.Add(oku["ilac_miktar"].ToString());

                    textBox1.Text = oku["hasta_tc"].ToString();

                    textBox13.Text = oku["doktor_tc"].ToString();
                    listView1.Items.Add(ekle);
                }

                oku.Close();
                SqlCommand komut2 = new SqlCommand("Select *from hasta where hasta_tc = " + Convert.ToInt64(textBox1.Text), baglan);
                SqlDataReader hastabilgi = komut2.ExecuteReader();
                SqlCommand komut3 = new SqlCommand("Select *from doktor where doktor_tc = " + Convert.ToInt64(textBox13.Text), baglan);

                while (hastabilgi.Read())
                {
                    textBox2.Text = hastabilgi["hasta_isim"].ToString();
                    textBox3.Text = hastabilgi["hasta_soyisim"].ToString();
                    textBox4.Text = hastabilgi["hasta_dogum"].ToString();
                    textBox5.Text = hastabilgi["hasta_cinsiyet"].ToString();
                    textBox6.Text = hastabilgi["hasta_adres"].ToString();
                }
                hastabilgi.Close();
                SqlDataReader doktorbilgi = komut3.ExecuteReader();

                while (doktorbilgi.Read())
                {
                    textBox12.Text = doktorbilgi["doktor_isim"].ToString();
                    textBox11.Text = doktorbilgi["doktor_soyisim"].ToString();
                    textBox10.Text = doktorbilgi["doktor_unvan"].ToString();
                    textBox9.Text = doktorbilgi["doktor_brans"].ToString();

                }
                doktorbilgi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama bulunamadı..!");
                             
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
           // textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;
            baglan.Open();
            recete_sorgulama("hasta_tc",textBox7.Text);
            baglan.Close();

        }

       /* private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;
            baglan.Open();
            recete_sorgulama("recete_id", textBox8.Text);
            baglan.Close();
        }*/

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
          /*  if (textBox8.Text.Count() == 11)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }*/
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fatura fatura_form = new fatura();
            fatura_form.recete_id = recete_id;
            fatura_form.receteli_satis = true;
            fatura_form.ilac_sayi = listView1.Items.Count;
            this.Hide();
            fatura_form.Show();
            
        }
    }
}
