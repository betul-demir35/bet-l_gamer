using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace betül_gamer
{
    public partial class Form3 : Form
    {
       
        string baglantiDizesi = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\EXCALİBUR\Desktop\ödevler\betül_gamer\betül_gamer\bin\Debug\oyun.accdb";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Oyun Adı", 150);
            listView1.Columns.Add("Oyun Fiyatı", 100);
            listView1.Columns.Add("Kategoriler", 100);
            listView1.Columns.Add("Oyun Çıkış Yılı", 100);


            comboBox2.Items.Clear();
            comboBox2.Items.Add("oyun_adi (Artan)");
            comboBox2.Items.Add("oyun_adi (Azalan)");
            comboBox2.Items.Add("oyun_fiyati (Artan)");
            comboBox2.Items.Add("oyun_fiyati (Azalan)");

            comboBox2.Items.Add("kategoriler (Artan)");
            comboBox2.Items.Add("kategoriler (Azalan)");
            comboBox2.Items.Add("oyun_cikis_yili (Artan)");
            comboBox2.Items.Add("oyun_cikis_yili (Azalan)");



            VerileriYukle();
        }

        
        private void VerileriYukle()
        {
            listView1.Items.Clear();

            string secim = "";
            if (comboBox2.SelectedItem != null)
                secim = comboBox2.SelectedItem.ToString();

            string siralamaKolonu = "oyun_adi";
            string siraYonu = "ASC";

            if (secim != "")
            {
                string[] parcalar = secim.Split(' ');
                siralamaKolonu = parcalar[0];
                if (parcalar[1] == "(Azalan)")
                    siraYonu = "DESC";
            }

            string sorguCumlesi = "SELECT * FROM ürünanahtarı ORDER BY " + siralamaKolonu + " " + siraYonu;
            OleDbConnection baglanti = new OleDbConnection(baglantiDizesi);
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand(sorguCumlesi, baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();

            while (okuyucu.Read())
            {
                ListViewItem satir = new ListViewItem(okuyucu["id"].ToString());
                satir.SubItems.Add(okuyucu["oyun_adi"].ToString());
                satir.SubItems.Add(okuyucu["oyun_fiyati"].ToString());
                satir.SubItems.Add(okuyucu["kategoriler"].ToString());
                satir.SubItems.Add(okuyucu["oyun_cikis_yili"].ToString());
                listView1.Items.Add(satir);
            }
            okuyucu.Close();
            baglanti.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem secilenSatir = listView1.SelectedItems[0];
                textBox2.Text = secilenSatir.SubItems[1].Text; 
                textBox3.Text = secilenSatir.SubItems[2].Text;
                comboBox1.Text = secilenSatir.SubItems[3].Text; 
                textBox4.Text = secilenSatir.SubItems[4].Text;
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
                textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
                MessageBox.Show("okii");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("aloo alan bos");
                return;
            }

            OleDbConnection baglanti = new OleDbConnection(baglantiDizesi);
            baglanti.Open();
            string sorguCumlesi = "INSERT INTO ürünanahtarı (oyun_adi, kategoriler, oyun_fiyati, oyun_cikis_yili) VALUES (?, ?, ?, ?)";
            OleDbCommand komut = new OleDbCommand(sorguCumlesi, baglanti);
            komut.Parameters.AddWithValue("?", textBox2.Text);
            komut.Parameters.AddWithValue("?", comboBox1.Text);
            komut.Parameters.AddWithValue("?", textBox3.Text);
            komut.Parameters.AddWithValue("?", textBox4.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("hoppa yeni oyun");
            VerileriYukle();

          
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("aloo ürün seçmedin");
                return;
            }

            string secilenID = listView1.SelectedItems[0].SubItems[0].Text;
            DialogResult cevap = MessageBox.Show("emin misin gardaş", "yeap", MessageBoxButtons.YesNo);
            if (cevap != DialogResult.Yes)
                return;

            OleDbConnection baglanti = new OleDbConnection(baglantiDizesi);
            baglanti.Open();
            string sorguCumlesi = "DELETE FROM ürünanahtarı WHERE id = ?";
            OleDbCommand komut = new OleDbCommand(sorguCumlesi, baglanti);
            komut.Parameters.AddWithValue("@p1", Convert.ToInt32(secilenID));
            int sonuc = komut.ExecuteNonQuery();
            if (sonuc > 0)
            {
                MessageBox.Show("pü gitti oyun");
                VerileriYukle();
            }
            else
            {
                MessageBox.Show("silemedin kanks");
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string secilenID = listView1.SelectedItems[0].SubItems[0].Text;
                OleDbConnection baglanti = new OleDbConnection(baglantiDizesi);
                baglanti.Open();
                string sorguCumlesi = "UPDATE ürünanahtarı SET oyun_adi = ?, kategoriler = ?, oyun_fiyati = ?, oyun_cikis_yili = ? WHERE id = ?";
                OleDbCommand komut = new OleDbCommand(sorguCumlesi, baglanti);
                komut.Parameters.AddWithValue("?", textBox2.Text);
                komut.Parameters.AddWithValue("?", comboBox1.Text);
                komut.Parameters.AddWithValue("?", textBox3.Text);
                komut.Parameters.AddWithValue("?", textBox4.Text);
                komut.Parameters.AddWithValue("?", Convert.ToInt32(secilenID));
                int sonuc = komut.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    MessageBox.Show("güncellem tamam ");
                    VerileriYukle();
                }
                else
                {
                    MessageBox.Show("olmadı beceriksiz");
                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("oyunu seç ki güncelliyim");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("e bu list bos");
                return;
            }

            double enYuksek = double.MinValue;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                double fiyat = Convert.ToDouble(listView1.Items[i].SubItems[2].Text);
                if (fiyat > enYuksek)
                    enYuksek = fiyat;
            }
            MessageBox.Show("en kazık oyun: " + enYuksek.ToString("C2"));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("list boş alo");
                return;
            }

            double enDusuk = double.MaxValue;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                double fiyat = Convert.ToDouble(listView1.Items[i].SubItems[2].Text);
                if (fiyat < enDusuk)
                    enDusuk = fiyat;
            }
            MessageBox.Show("beleş oyun al: " + enDusuk.ToString("C2"));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<ListViewItem> elemanlar = new List<ListViewItem>();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                elemanlar.Add(listView1.Items[i]);
            }

            elemanlar.Sort((a, b) =>
            {
                double fiyatA = Convert.ToDouble(a.SubItems[2].Text);
                double fiyatB = Convert.ToDouble(b.SubItems[2].Text);
                return fiyatB.CompareTo(fiyatA);
            });

            List<ListViewItem> top5 = new List<ListViewItem>();
            int adet = elemanlar.Count > 5 ? 5 : elemanlar.Count;
            for (int i = 0; i < adet; i++)
            {
                top5.Add(elemanlar[i]);
            }

            listView1.Items.Clear();
            foreach (ListViewItem item in top5)
            {
                listView1.Items.Add((ListViewItem)item.Clone());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
