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
    public partial class ilac_kayit : Form
    {
        public ilac_kayit()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RS972Q5;Initial Catalog=eczane_otomasyon;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Insert into ilaç(ilac_isim,ilac_stok,ilac_fiyat,son_k_tarih,firma_isim) Values ('" + textBox1.Text.ToString() + "','" + Convert.ToInt16(textBox7.Text) + "','" + textBox6.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "')", baglan);
 
                komut.ExecuteNonQuery();

                baglan.Close();
                MessageBox.Show(textBox1.Text+" İsimli İlaç Kaydedildi..");

                textBox1.Text="";
                textBox2.Text = "";               
                comboBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt Başarısız..");
            }
            baglan.Close();
        }

        private void ilac_kayit_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("Select *from firma", baglan);

            SqlDataReader oku = komut2.ExecuteReader();

            while (oku.Read())
            {
                comboBox1.Items.Add(oku["firma_isim"].ToString());
            }
            baglan.Close();
        }
    }
}
