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
    public partial class fatura : Form
    {
        public fatura()
        {
            InitializeComponent();
        }
        public void atama()
        {
            ilac_isim = new string[ilac_sayi];
            

            if (ilac_sayi == 1)
            {
                ilac_isim[0]=label2.Text;
            }else if (ilac_sayi == 2)
            {
                ilac_isim[0] = label2.Text;
                ilac_isim[1] = label3.Text;
            }else if (ilac_sayi == 3)
            {
                ilac_isim[0] = label2.Text;
                ilac_isim[1] = label3.Text;
                ilac_isim[2] = label4.Text;
            }else if (ilac_sayi == 4)
            {
                ilac_isim[0] = label2.Text;
                ilac_isim[1] = label3.Text;
                ilac_isim[2] = label4.Text;
                ilac_isim[3] = label5.Text;
            }else if (ilac_sayi == 5)
            {
                ilac_isim[0] = label2.Text;
                ilac_isim[1] = label3.Text;
                ilac_isim[2] = label4.Text;
                ilac_isim[3] = label5.Text;
                ilac_isim[4] = label6.Text;
            }else if (ilac_sayi == 6)
            {
                ilac_isim[0] = label2.Text;
                ilac_isim[1] = label3.Text;
                ilac_isim[2] = label4.Text;
                ilac_isim[3] = label5.Text;
                ilac_isim[4] = label6.Text;
                ilac_isim[5] = label7.Text;
            }
        }
        public void receteli_satis_fonk()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from receteid_ilacisim  rid Inner Join ilaç I On rid.ilac_isim=I.ilac_isim   where recete_id = " + recete_id, baglan);
            SqlDataReader oku = komut.ExecuteReader();

            int i = 0;
            ilac_fiyat = new int[ilac_sayi];
            while (oku.Read())
            {

                 if (i == 0)
                 {
                     label2.Text = oku["ilac_isim"].ToString();
                     //  ilac_isim[i] = label2.Text;
                     textBox1.Text = oku["ilac_miktar"].ToString();
                     ilac_fiyat[i] = Convert.ToInt16(oku["ilac_fiyat"]);
                     
                 }
                 else if (i == 1)
                 {
                     label3.Text = oku["ilac_isim"].ToString();
                     //   ilac_isim[i] = label3.Text;
                     textBox2.Text = oku["ilac_miktar"].ToString();
                     ilac_fiyat[i] = Convert.ToInt16(oku["ilac_fiyat"]);
                 }
                 else if (i == 2)
                 {
                     label4.Text = oku["ilac_isim"].ToString();
                     //  ilac_isim[i] = label4.Text;
                     textBox3.Text = oku["ilac_miktar"].ToString();
                     ilac_fiyat[i] = Convert.ToInt16(oku["ilac_fiyat"]);

                 }
                 else if (i == 3)
                 {
                     label5.Text = oku["ilac_isim"].ToString();
                     //ilac_isim[i] = label5.Text;
                     textBox4.Text = oku["ilac_miktar"].ToString();
                     ilac_fiyat[i] = Convert.ToInt16(oku["ilac_fiyat"]);

                 }
                 else if (i == 4)
                 {
                     label6.Text = oku["ilac_isim"].ToString();
                     // ilac_isim[i] = label6.Text;
                     textBox5.Text = oku["ilac_miktar"].ToString();
                     ilac_fiyat[i] = Convert.ToInt16(oku["ilac_fiyat"]);

                 }
                 else if (i == 5)
                 {
                     label7.Text = oku["ilac_isim"].ToString();
                     //ilac_isim[i] = label7.Text;
                     textBox6.Text = oku["ilac_miktar"].ToString();
                     ilac_fiyat[i] = Convert.ToInt16(oku["ilac_fiyat"]);

                 }
                 i++;
            }
             oku.Close();
            baglan.Close();      
        }

        public void recetesiz_satis_fonk()
        {
            baglan.Open();
            int i = 0;
            recetesiz_fiyat = new double[ilac_sayi];
            while (i<ilac_sayi)
            {
                SqlCommand komut = new SqlCommand("Select * from ilaç where ilac_isim Like '" + ilac_isim[i] + "%'", baglan);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    recetesiz_fiyat[i] = Convert.ToDouble(oku["ilac_fiyat"]);
                }

                oku.Close();
                
                i++;
            }




            
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RS972Q5;Initial Catalog=eczane_otomasyon;Integrated Security=True");
        string[] ilac_isim;
        int[] ilac_fiyat;
        int[] ilac_miktar;
        int[] ilac_stok;
        double[] recetesiz_fiyat;
        public int ilac_sayi;        
        public int recete_id;
        float toplam_fiyat= 0f;
        int son_kayit_id;
         String eczane_isim="PINAR ECZANESİ";
        public bool receteli_satis, recetesiz_satis;
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                baglan.Open();
                SqlCommand son_id = new SqlCommand("SELECT * FROM ilac_satis ORDER BY satis_id DESC", baglan);
                son_kayit_id = Convert.ToInt16(son_id.ExecuteScalar().ToString());              
                son_kayit_id++;

                SqlCommand komut2 = new SqlCommand("Insert into ilac_satis(satis_id,eczane_isim) Values ('" + son_kayit_id + "','" + eczane_isim + "')", baglan);
                komut2.ExecuteNonQuery();

                SqlCommand recete_sil = new SqlCommand("Delete From Recete where recete_id=(" + recete_id + ")", baglan);
                recete_sil.ExecuteNonQuery();
                
                int i = 0;
                while (i<ilac_sayi)
                {
                    SqlCommand komut = new SqlCommand("Insert into ilac_isim_id(satis_id,ilac_isim,ilac_satim_miktar) Values ('" + son_kayit_id + "','" + ilac_isim[i] + "','" + ilac_miktar[i] + "')", baglan);
                    komut.ExecuteNonQuery();
                    i++;
                }

               



                baglan.Close();
                label2.Text = "null"; 
                label3.Text = "null";
                label4.Text = "null";
                label5.Text = "null";
                label6.Text = "null";
                label7.Text = "null";
                label44.Text = "null";
                label45.Text = "null";
                label46.Text = "null";
                label47.Text = "null";
                textBox1.Text = "null";
                textBox2.Text = "null";
                textBox3.Text = "null";
                textBox4.Text = "null";
                textBox5.Text = "null";
                textBox6.Text = "null";

            }
            catch (Exception ex)
            {
                baglan.Close();
            }
        }

        private void fatura_FormClosing(object sender, FormClosingEventArgs e)
        {
            

            recete recete_form = new recete();
            recete_form.Close();
           
        }

        private void fatura_Load(object sender, EventArgs e)
        {

            if (receteli_satis == true)
            {
                receteli_satis_fonk();
                atama();
                ilac_miktar = new int[6];
                ilac_miktar[0] = Convert.ToInt16(textBox1.Text);
                ilac_miktar[1] = Convert.ToInt16(textBox2.Text);
                ilac_miktar[2] = Convert.ToInt16(textBox3.Text);
                ilac_miktar[3] = Convert.ToInt16(textBox4.Text);
                ilac_miktar[4] = Convert.ToInt16(textBox5.Text);
                ilac_miktar[5] = Convert.ToInt16(textBox6.Text);
                for (int i = 0; i < ilac_sayi; i++)
                {
                    toplam_fiyat += (float)ilac_fiyat[i] * ilac_miktar[i];
                }
                label44.Text = toplam_fiyat.ToString() + "₺";
                float sgk_indirim = (toplam_fiyat / 100f * 60f);
                label45.Text = "-" + (sgk_indirim).ToString() + "₺";
                float muayene_ücret = 5f;
                label46.Text = muayene_ücret + "₺";
                label47.Text = (toplam_fiyat - sgk_indirim + muayene_ücret).ToString() + "₺";
            }

            //***************************************************
            if (recetesiz_satis == true)
            {
                atama();
                recetesiz_satis_fonk();
                ilac_miktar = new int[6];
                ilac_miktar[0] = Convert.ToInt16(textBox1.Text);
                ilac_miktar[1] = Convert.ToInt16(textBox2.Text);
                ilac_miktar[2] = Convert.ToInt16(textBox3.Text);
                ilac_miktar[3] = Convert.ToInt16(textBox4.Text);
                ilac_miktar[4] = Convert.ToInt16(textBox5.Text);
                ilac_miktar[5] = Convert.ToInt16(textBox6.Text);
                for (int i = 0; i < ilac_sayi; i++)
                {
                    toplam_fiyat += (float)recetesiz_fiyat[i] * ilac_miktar[i];
                }
                label44.Text = toplam_fiyat.ToString() + "₺";
                label45.Text = "-0 ₺";
                label46.Text = "0 ₺";
                label47.Text = (toplam_fiyat).ToString() + "₺";

            }

        }
    }
}
