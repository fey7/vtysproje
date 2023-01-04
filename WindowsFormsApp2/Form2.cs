using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        Class1 class1 = new Class1();

        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cumle = "select S_Ad+' '+S_Soyad as 'Satıcı', S_TelNo as 'Tel No', Urun_Adi\r\nfrom SATICI inner join URUN \r\non SATICI.Urun_No = URUN.Urun_No";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = class1.listele(adtr2, cumle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cumle = "select Kat_Adi as 'Kategori', Urun_Adi,Fiyati\r\nfrom URUN inner join KATEGORI \r\non URUN.Kat_No=KATEGORI.Kat_No";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = class1.listele(adtr2, cumle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fatura_no = textBox1.Text;
            string cumle = "select M_Ad+' '+M_Soyad as 'Müşteri', Siparis_No as\t'Sipariş', Tutar, Mıktar as 'Miktar', Tarih\r\nfrom FATURA inner join MUSTERI\r\non FATURA.Musteri_No=MUSTERI.Musteri_No where Fatura_No = '" + textBox1.Text + "'";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = class1.listele(adtr2, cumle);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            string cumle = "insert into MUSTERI(M_Ad,M_Soyad,M_TelNo,M_EMail,M_Adres,M_KullaniciAd,M_Sifre) values( @M_Ad, @M_Soyad, @M_TelNo, @M_EMail, @M_Adres,@M_KullaniciAd, @M_Sifre)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@M_Ad", txtad.Text);
            komut2.Parameters.AddWithValue("@M_Soyad", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@M_TelNo", txttel.Text);
            komut2.Parameters.AddWithValue("@M_EMail", txtmail.Text);
            komut2.Parameters.AddWithValue("@M_Adres", txtadres.Text);
            komut2.Parameters.AddWithValue("@M_KullaniciAd", txtkullanici.Text);
            komut2.Parameters.AddWithValue("@M_Sifre", txtsifre.Text);

            class1.ekle_sil_güncelle(komut2, cumle);

        }

        private void YenileListele()
        {
            string cumle = "select *from MUSTERI";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = class1.listele(adtr2, cumle);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YenileListele();
        }

        private void txtmtel_TextChanged(object sender, EventArgs e)
        {
            string cumle = "select *from MUSTERI where M_TelNo like '%"+txtmtel.Text+"%'";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = class1.listele(adtr2, cumle);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtad.Text = satır.Cells[1].Value.ToString();
            txtsoyad.Text = satır.Cells[2].Value.ToString();
            txttel.Text = satır.Cells[3].Value.ToString();
            txtmail.Text = satır.Cells[4].Value.ToString();
            txtadres.Text = satır.Cells[5].Value.ToString();
            txtkullanici.Text = satır.Cells[6].Value.ToString();
            txtsifre.Text = satır.Cells[7].Value.ToString();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            string cumle = "update MUSTERI set  M_Ad=@M_Ad, M_Soyad=@M_Soyad, M_TelNo=@M_TelNo, M_EMail=@M_EMail, M_Adres=@M_Adres, M_KullaniciAd=@M_KullaniciAd, M_Sifre=@M_Sifre";
            SqlCommand komut2 = new SqlCommand();

            komut2.Parameters.AddWithValue("@M_Ad", txtad.Text);
            komut2.Parameters.AddWithValue("@M_Soyad", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@M_TelNo", txttel.Text);
            komut2.Parameters.AddWithValue("@M_EMail", txtmail.Text);
            komut2.Parameters.AddWithValue("@M_Adres", txtadres.Text);
            komut2.Parameters.AddWithValue("@M_KullaniciAd", txtkullanici.Text);
            komut2.Parameters.AddWithValue("@M_Sifre", txtsifre.Text);

            class1.ekle_sil_güncelle(komut2, cumle);
            YenileListele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cumle = "delete from MUSTERI where M_Ad = '" + satır.Cells["M_Ad"].Value.ToString() +"'";
            SqlCommand komut2 = new SqlCommand();
            class1.ekle_sil_güncelle(komut2, cumle);
            YenileListele();

        }
    }
}
