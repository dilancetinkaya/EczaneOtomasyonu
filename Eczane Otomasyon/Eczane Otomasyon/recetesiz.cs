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
    public partial class recetesiz : Form
    {
        public recetesiz()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RS972Q5;Initial Catalog=eczane_otomasyon;Integrated Security=True");


        private void ilaclistele()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from ilaç", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ilac_isim"].ToString();              
                ekle.SubItems.Add(oku["ilac_stok"].ToString());
               
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void harf_listele(String harf)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM ilaç WHERE ilac_isim LIKE '" + harf + "%'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ilac_isim"].ToString();
                ekle.SubItems.Add(oku["firma_isim"].ToString());
                ekle.SubItems.Add(oku["son_k_tarih"].ToString());
                ekle.SubItems.Add(oku["ilac_stok"].ToString());
                String fiyat = (oku["ilac_fiyat"].ToString() + "TL");

                ekle.SubItems.Add(fiyat);
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void recetesiz_Load(object sender, EventArgs e)
        {
            ilaclistele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from ilaç where ilac_isim = '" + Convert.ToString(textBox1.Text) + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ilac_isim"].ToString();
                ekle.SubItems.Add(oku["ilac_stok"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            harf_listele(label14.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            harf_listele(label5.Text);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            harf_listele(label6.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            harf_listele(label3.Text);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            harf_listele(label7.Text);
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

        private void label29_Click(object sender, EventArgs e)
        {
            harf_listele(label29.Text);
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
        int sira=1;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(sira==1)
                label49.Text = listView1.SelectedItems[0].SubItems[0].Text;
            if(sira==2)
                label48.Text = listView1.SelectedItems[0].SubItems[0].Text;
            if (sira == 3)
                label47.Text = listView1.SelectedItems[0].SubItems[0].Text;
            if (sira == 4)
                label46.Text = listView1.SelectedItems[0].SubItems[0].Text;
            if (sira == 5)
                label45.Text = listView1.SelectedItems[0].SubItems[0].Text;
            if (sira == 6)
                label44.Text = listView1.SelectedItems[0].SubItems[0].Text;
            sira++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fatura fatura_goster = new fatura();
            fatura_goster.recetesiz_satis = true;
            this.Hide();
            fatura_goster.label2.Text = label49.Text;
            fatura_goster.label3.Text = label48.Text;
            fatura_goster.label4.Text = label47.Text;
            fatura_goster.label5.Text = label46.Text;
            fatura_goster.label6.Text = label45.Text;
            fatura_goster.label7.Text = label44.Text;
            fatura_goster.textBox1.Text = textBox7.Text;
            fatura_goster.textBox2.Text = textBox2.Text;
            fatura_goster.textBox3.Text = textBox3.Text;
            fatura_goster.textBox4.Text = textBox4.Text;
            fatura_goster.textBox5.Text = textBox5.Text;
            fatura_goster.textBox6.Text = textBox6.Text;
            fatura_goster.ilac_sayi = sira - 1;

            fatura_goster.Show();
            

        }
    }
}
