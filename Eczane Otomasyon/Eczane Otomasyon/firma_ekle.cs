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
    public partial class firma_ekle : Form
    {
        public firma_ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RS972Q5;Initial Catalog=eczane_otomasyon;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Insert into firma(firma_isim,firma_telefon) Values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show(textBox1.Text + " Firması Kaydedildi..");
                textBox1.Text = "";
                textBox2.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt Başarısız..");
                textBox1.Focus();
            }
            baglan.Close();
        }
    }
}
