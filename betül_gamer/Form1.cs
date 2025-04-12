using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace betül_gamer
{
    public partial class Form1 : Form
    {
        // Veritabanı bağlantısı için değişken
        OleDbConnection baglanti;
        // Bağlantı dizesi (connection string)
        string baglantiDizesi = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\EXCALİBUR\Desktop\betuloyun\betuloyun\bin\Debug\oyun.accdb";

        public Form1()
        {
            InitializeComponent();
            // Bağlantı nesnesi oluşturuluyor
            baglanti = new OleDbConnection(baglantiDizesi);
        }

       
        private void DATAGRİDVİEW_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }


    }
}
