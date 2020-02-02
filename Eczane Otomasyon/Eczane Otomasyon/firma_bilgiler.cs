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
    public partial class firma_bilgiler : Form
    {
        public firma_bilgiler()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RS972Q5;Initial Catalog=eczane_otomasyon;Integrated Security=True");


        private void firma_listele()
        {
            
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from firma", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {

                comboBox1.Items.Add(oku["firma_isim"].ToString());
            }
            baglan.Close();
        }
        private void firma_bilgiler_Load(object sender, EventArgs e)
        {
            firma_listele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String firma = comboBox1.Text;
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from firma", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                if (oku["firma_isim"].ToString() == firma)
                {
                    label3.Text= oku["firma_telefon"].ToString();
                    
                }
            }
            baglan.Close();
        }
    }
}
