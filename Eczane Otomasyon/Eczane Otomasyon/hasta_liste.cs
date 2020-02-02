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
    public partial class hasta_liste : Form
    {
        public hasta_liste()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RS972Q5;Initial Catalog=eczane_otomasyon;Integrated Security=True");
        private void hasta_listele()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from hasta H INNER JOIN doktor D ON H.doktor_tc=D.doktor_tc",baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["hasta_tc"].ToString(); 
                ekle.SubItems.Add(oku["hasta_isim"].ToString());
                ekle.SubItems.Add(oku["hasta_soyisim"].ToString());
                int yas = 2019 - Convert.ToInt32(oku["hasta_dogum"]);
                //Günümüze göre yası günceller
                ekle.SubItems.Add(yas.ToString());
                ekle.SubItems.Add(oku["hasta_cinsiyet"].ToString());
                ekle.SubItems.Add(oku["hasta_adres"].ToString());
                // string doktor_isim = oku["doktor_isim"].ToString();
                //string doktor_soyisim = oku["doktor_soyisim"].ToString();

                String[] doktor_isim;
                doktor_isim = oku["doktor_isim"].ToString().Split(' ');
                //ekle.SubItems.Add(doktor_isim[0]);

                String[] doktor_soyisim;
                doktor_soyisim = oku["doktor_soyisim"].ToString().Split(' ');
                ekle.SubItems.Add(doktor_isim[0]+"  "+doktor_soyisim[0]);


                listView1.Items.Add(ekle);
            }
                baglan.Close();
        }
        private void harf_listele(String harf)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM hasta H INNER JOIN doktor D ON H.doktor_tc=D.doktor_tc WHERE hasta_isim LIKE '" + harf+"%'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["hasta_tc"].ToString();
                ekle.SubItems.Add(oku["hasta_isim"].ToString());
                ekle.SubItems.Add(oku["hasta_soyisim"].ToString());
                int yas = 2019 - Convert.ToInt32(oku["hasta_dogum"]);
                ekle.SubItems.Add(yas.ToString());
                ekle.SubItems.Add(oku["hasta_cinsiyet"].ToString());
                ekle.SubItems.Add(oku["hasta_adres"].ToString());

                String[] doktor_isim;
                doktor_isim = oku["doktor_isim"].ToString().Split(' ');
                //ekle.SubItems.Add(doktor_isim[0]);

                String[] doktor_soyisim;
                doktor_soyisim = oku["doktor_soyisim"].ToString().Split(' ');
                ekle.SubItems.Add(doktor_isim[0] + "  " + doktor_soyisim[0]);

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void hasta_liste_Load(object sender, EventArgs e)
        {
            hasta_listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from hasta H INNER JOIN doktor D ON H.doktor_tc=D.doktor_tc where hasta_tc = " + Convert.ToInt64(textBox1.Text), baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["hasta_tc"].ToString();
                ekle.SubItems.Add(oku["hasta_isim"].ToString());
                ekle.SubItems.Add(oku["hasta_soyisim"].ToString());
                int yas = 2019 - Convert.ToInt32(oku["hasta_dogum"]);
                ekle.SubItems.Add(yas.ToString());
                ekle.SubItems.Add(oku["hasta_cinsiyet"].ToString());
                ekle.SubItems.Add(oku["hasta_adres"].ToString());

                String[] doktor_isim;
                doktor_isim = oku["doktor_isim"].ToString().Split(' ');
                //ekle.SubItems.Add(doktor_isim[0]);

                String[] doktor_soyisim;
                doktor_soyisim = oku["doktor_soyisim"].ToString().Split(' ');
                ekle.SubItems.Add(doktor_isim[0] + "  " + doktor_soyisim[0]);

                listView1.Items.Add(ekle);
            }
            baglan.Close();
            textBox1.SelectAll();
           // textBox1.Focus();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            harf_listele(label14.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            harf_listele(label15.Text);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            harf_listele(label6.Text);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            harf_listele(label17.Text);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            harf_listele(label8.Text);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            harf_listele(label9.Text);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            harf_listele(label10.Text);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            harf_listele(label11.Text);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            harf_listele(label12.Text);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            harf_listele(label13.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            harf_listele(label3.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            harf_listele(label1.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            harf_listele(label2.Text);
        }

        private void label28_Click(object sender, EventArgs e)
        {
            harf_listele(label28.Text);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            harf_listele(label15.Text);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            harf_listele(label16.Text);
        }

        private void label17_Click(object sender, EventArgs e)
        {
            harf_listele(label17.Text);
        }

        private void label18_Click(object sender, EventArgs e)
        {
            harf_listele(label18.Text);
        }

        private void label19_Click(object sender, EventArgs e)
        {
            harf_listele(label19.Text);
        }

        private void label20_Click(object sender, EventArgs e)
        {
            harf_listele(label20.Text);
        }

        private void label21_Click(object sender, EventArgs e)
        {
            harf_listele(label21.Text);
        }

        private void label30_Click(object sender, EventArgs e)
        {
            harf_listele(label30.Text);
        }

        private void label23_Click(object sender, EventArgs e)
        {
            harf_listele(label23.Text);
        }

        private void label24_Click(object sender, EventArgs e)
        {
            harf_listele(label24.Text);
        }

        private void label25_Click(object sender, EventArgs e)
        {
            harf_listele(label25.Text);
        }

        private void label26_Click(object sender, EventArgs e)
        {
            harf_listele(label26.Text);
        }

        private void label27_Click(object sender, EventArgs e)
        {
            harf_listele(label27.Text);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            harf_listele(label4.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Count() == 11)
            {
                button1.Enabled = true;
            }else
            {
                button1.Enabled = false;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            baglan.Open();
            hasta_guncelle hasta_guncelleme = new hasta_guncelle();
            hasta_guncelleme.id = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            hasta_guncelleme.textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            hasta_guncelleme.textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            hasta_guncelleme.textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            hasta_guncelleme.textBox4.Text = (2019 - Convert.ToInt32(listView1.SelectedItems[0].SubItems[3].Text)).ToString();
            hasta_guncelleme.textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
            hasta_guncelleme.textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            String[] doktor_isim = listView1.SelectedItems[0].SubItems[6].Text.Split(' ');

            SqlCommand komut = new SqlCommand("Select * from doktor where doktor_isim ='" + doktor_isim[0] + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            
            while (oku.Read())
            {
                hasta_guncelleme.textBox7.Text = oku["doktor_tc"].ToString();
            }
                
            
            hasta_guncelleme.Show();
            baglan.Close();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
