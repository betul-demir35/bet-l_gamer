using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace betül_gamer
{
    public partial class Form2 : Form
    {
     
        string baglantiDizesi = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\EXCALİBUR\Desktop\ödevler\betül_gamer\betül_gamer\bin\Debug\oyun.accdb";

        public Form2()
        {
            InitializeComponent();
        }

       
        private void Form2_Load(object sender, EventArgs e)
        {
        
            string sorgu = "SELECT [oyun_adi], [oyun_fiyati], [kategoriler], [oyun_cikis_yili] FROM [ürünanahtarı]";
            OleDbConnection baglanti = new OleDbConnection(baglantiDizesi);
            baglanti.Open();
            OleDbDataAdapter adaptor = new OleDbDataAdapter(sorgu, baglanti);
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();



            comboBox2.Items.Clear();
            comboBox2.Items.Add("oyun_adi (Artan)");
            comboBox2.Items.Add("oyun_adi (Azalan)");
            comboBox2.Items.Add("oyun_fiyati (Artan)");
            comboBox2.Items.Add("oyun_fiyati (Azalan)");
            comboBox2.Items.Add("kategoriler (Artan)");
            comboBox2.Items.Add("kategoriler (Azalan)");
            comboBox2.Items.Add("oyun_cikis_yili (Artan)");
            comboBox2.Items.Add("oyun_cikis_yili (Azalan)");
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
          
            if (textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("hop bos alan");
            }
            else
            {
                string oyunAdi = textBox2.Text;
                string kategori = comboBox1.Text;
                string oyunFiyati = textBox3.Text;
                string oyunCikisYili = textBox4.Text;

                OleDbConnection baglanti = new OleDbConnection(baglantiDizesi);
                baglanti.Open();
                string sorgu = "INSERT INTO ürünanahtarı (oyun_adi, oyun_fiyati, kategoriler, oyun_cikis_yili) " +
                               "VALUES (@oyunAdi, @oyunFiyati, @kategori, @oyunCikisYili)";
                OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@oyunAdi", oyunAdi);
                komut.Parameters.AddWithValue("@oyunFiyati", oyunFiyati);
                komut.Parameters.AddWithValue("@kategori", kategori);
                komut.Parameters.AddWithValue("@oyunCikisYili", oyunCikisYili);
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("yeni ürün ho");
                Form2_Load(null, null); 

            
                textBox2.Text = "";
                comboBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
          
            if (dataGridView1.SelectedRows.Count > 0)
            {
               
                string oyunAdi = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
               
                string sorgu = "DELETE FROM ürünanahtarı WHERE oyun_adi = '" + oyunAdi + "'";
                OleDbConnection baglanti = new OleDbConnection(baglantiDizesi);
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("pü gitti oyun");
                Form2_Load(null, null);
            }
            else
            {
                MessageBox.Show("satır seçmedin kanks");
            }
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("boş alan bıraktın olmaz böyle");
            }
            else
            {
                OleDbConnection baglanti = new OleDbConnection(baglantiDizesi);
                baglanti.Open();
                string sorgu = "UPDATE ürünanahtarı SET oyun_fiyati = @oyunFiyati, kategoriler = @kategori, " +
                               "oyun_cikis_yili = @oyunCikisYili WHERE oyun_adi = @oyunAdi";
                OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@oyunFiyati", textBox3.Text);
                komut.Parameters.AddWithValue("@kategori", comboBox1.Text);
                komut.Parameters.AddWithValue("@oyunCikisYili", textBox4.Text);
                komut.Parameters.AddWithValue("@oyunAdi", textBox2.Text);
                int sonuc = komut.ExecuteNonQuery();
                baglanti.Close();

                if (sonuc > 0)
                {
                    MessageBox.Show("güncelleme tamamdır");
                    Form2_Load(null, null);

                   
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("ürün yok ki neyi güncelliyon");
                }
            }
        }

      
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double enYuksekFiyat = -1;
         
            foreach (DataGridViewRow satir in dataGridView1.Rows)
            {
                if (satir.Cells["oyun_fiyati"].Value != null)
                {
                   
                    double fiyat = Convert.ToDouble(satir.Cells["oyun_fiyati"].Value.ToString());
                    if (fiyat > enYuksekFiyat)
                    {
                        enYuksekFiyat = fiyat;
                    }
                }
            }
            if (enYuksekFiyat != -1)
                MessageBox.Show("kazık oyun: " + enYuksekFiyat.ToString("C2"));
            else
                MessageBox.Show("yok bulamadım");
        }

       
        private void button6_Click(object sender, EventArgs e)
        {
            double enDusukFiyat = double.MaxValue;
            foreach (DataGridViewRow satir in dataGridView1.Rows)
            {
                if (satir.Cells["oyun_fiyati"].Value != null)
                {
                    double fiyat = Convert.ToDouble(satir.Cells["oyun_fiyati"].Value.ToString());
                    if (fiyat < enDusukFiyat)
                    {
                        enDusukFiyat = fiyat;
                    }
                }
            }
            if (enDusukFiyat != double.MaxValue)
                MessageBox.Show("beleş oyun: " + enDusukFiyat.ToString("C2"));
            else
                MessageBox.Show("bulamadım sorry");
        }

       
        private void button7_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection(baglantiDizesi);
            baglanti.Open();
            string sorgu = "SELECT TOP 5 [oyun_adi], [oyun_fiyati], [kategoriler], [oyun_cikis_yili] " +
                           "FROM [ürünanahtarı] ORDER BY oyun_fiyati DESC";
            OleDbDataAdapter adaptor = new OleDbDataAdapter(sorgu, baglanti);
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

       
        private void button8_Click(object sender, EventArgs e)
        {
            Form2_Load(null, null);
        }

        
        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                
                string secilen = comboBox2.SelectedItem.ToString();
                string[] parcalar = secilen.Split(' ');
                if (parcalar.Length >= 2)
                {
                    string kolon = parcalar[0]; 
                    string siralama = parcalar[1];
                    string sorgu = "";

                    if (siralama == "(Artan)")
                    {
                        sorgu = "SELECT [oyun_adi], [oyun_fiyati], [kategoriler], [oyun_cikis_yili] FROM [ürünanahtarı] ORDER BY " + kolon + " ASC";
                    }
                    else
                    {
                        sorgu = "SELECT [oyun_adi], [oyun_fiyati], [kategoriler], [oyun_cikis_yili] FROM [ürünanahtarı] ORDER BY " + kolon + " DESC";
                    }

                    OleDbConnection baglanti = new OleDbConnection(baglantiDizesi);
                    baglanti.Open();
                    OleDbDataAdapter adaptor = new OleDbDataAdapter(sorgu, baglanti);
                    DataTable tablo = new DataTable();
                    adaptor.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("kanka neyi sıralıyon seçmedin ki");
            }
        }
    }
}
